using UnityEngine;
using System.Collections;

/*
 * Example implementation of the SuperStateMachine and SuperCharacterController
 */
[RequireComponent(typeof(SuperCharacterController))]
[RequireComponent(typeof(PlayerInputController))]
public class PlayerMachine : SuperStateMachine {

    public Transform AnimatedMesh;

    public float WalkSpeed = 4.0f;
    public float WalkAcceleration = 30.0f;
    public float JumpAcceleration = 5.0f;
    public float JumpHeight = 3.0f;
    public float Gravity = 25.0f;

    // Add more states by comma separating them
    enum PlayerStates { Idle, Walk, Jump, Fall }

    private SuperCharacterController controller;

    // current velocity
    private Vector3 moveDirection;
    // current direction our character's art is facing
    public Vector3 lookDirection { get; private set; }

    private PlayerInputController input;

	void Start () {
	    // Put any code here you want to run ONCE, when the object is initialized

        input = gameObject.GetComponent<PlayerInputController>();

        // Grab the controller object from our object
        controller = gameObject.GetComponent<SuperCharacterController>();
		
		// Our character's current facing direction, planar to the ground
        lookDirection = transform.forward;

        // Set our currentState to idle on startup
        currentState = PlayerStates.Idle;
	}

    protected override void EarlyGlobalSuperUpdate()
    {
		// Rotate out facing direction horizontally based on mouse input
        lookDirection = Quaternion.AngleAxis(input.Current.MouseInput.x, Vector3.up) * lookDirection;
        // Put any code in here you want to run BEFORE the state's update function.
        // This is run regardless of what state you're in
    }

    protected override void LateGlobalSuperUpdate()
    {
        // Put any code in here you want to run AFTER the state's update function.
        // This is run regardless of what state you're in

        // Move the player by our velocity every frame
        transform.position += moveDirection * Time.deltaTime;

        // Rotate our mesh to face where we are "looking"
        AnimatedMesh.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
    }

    // Very basic grounding function that ensures we are close enough for our "feet" to touch the ground
    // And that we are not standing right on the edge of a cliff
    private bool IsGrounded(float distance)
    {            
        if (controller.currentGround.Hit.distance > distance)
        {
            return false;
        }

        Vector3 projectedHitPoint = Math3d.ProjectPointOnPlane(Vector3.up, transform.position, controller.currentGround.Hit.point);

        if (Vector3.Distance(projectedHitPoint, transform.position) > controller.radius * 0.5f)
        {
            return false;
        }

        return true;
    }
	
	// More advanced grounding function. This takes into account that we may be standing on sloped
	// Ground, or walking from sloped ground onto flat surfaces. You'll want to modify this if you need
	// Specific grounding behaviour
	private bool IsGroundedAdvanced(float distance, bool currentlyGrounded)
    {
        if (controller.currentGround.Hit.distance > distance)
        {
            return false;
        }

        Vector3 n = controller.currentGround.FarHit.normal;
        float angle = Vector3.Angle(n, Vector3.up);

        if (angle > controller.currentGround.CollisionType.StandAngle)
        {
            return false;
        }

        float upperBoundAngle = 60.0f;

        float maxDistance = 0.96f;
        float minDistance = 0.50f;

        float angleRatio = angle / upperBoundAngle;

        float distanceRatio = Mathf.Lerp(minDistance, maxDistance, angleRatio);

        Vector3 p = Math3d.ProjectPointOnPlane(controller.up, transform.position, controller.currentGround.Hit.point);

        bool steady = Vector3.Distance(p, transform.position) <= distanceRatio * controller.radius;

        if (!steady)
        {
            if (!currentlyGrounded)
            {
                return false;
            }

            if (controller.currentGround.NearHit.distance < distance)
            {
                if (Vector3.Angle(controller.currentGround.NearHit.normal, controller.up) > controller.currentGround.CollisionType.StandAngle)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    private bool AcquiringGround()
    {
        return IsGroundedAdvanced(0.01f, false);
    }

    private bool MaintainingGround()
    {
        return IsGroundedAdvanced(0.5f, true);
    }

    private Vector3 LocalMovement()
    {
        Vector3 right = Vector3.Cross(Vector3.up, lookDirection);

        Vector3 local = Vector3.zero;

        if (input.Current.MoveInput.x != 0)
        {
            local += right * input.Current.MoveInput.x;
        }

        if (input.Current.MoveInput.z != 0)
        {
            local += lookDirection * input.Current.MoveInput.z;
        }

        return local;
    }

    // Calculate the initial velocity of a jump based off gravity and desired maximum height attained
    private float CalculateJumpSpeed(float jumpHeight, float gravity)
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

	/*void Update () {
	 * Update is normally run once on every frame update. We won't be using it
     * in this case, since the SuperCharacterController component sends a callback Update 
     * called SuperUpdate. SuperUpdate is recieved by the SuperStateMachine, and then fires
     * further callbacks depending on the state
	}*/

    // Below are the three state functions. Each one is called based on the name of the state,
    // so when currentState = Idle, we call Idle_EnterState. If currentState = Jump, we call
    // Jump_SuperUpdate()
    void Idle_EnterState()
    {
        controller.EnableSlopeLimit();
        controller.EnableClamping();
    }

    void Idle_SuperUpdate()
    {
        // Run every frame we are in the idle state

        if (input.Current.JumpInput)
        {
            currentState = PlayerStates.Jump;
            return;
        }

        if (!MaintainingGround())
        {
            currentState = PlayerStates.Fall;
            return;
        }

        if (input.Current.MoveInput != Vector3.zero)
        {
            currentState = PlayerStates.Walk;
            return;
        }

        // Apply friction to slow us to a halt
        moveDirection = Vector3.MoveTowards(moveDirection, Vector3.zero, 10.0f * Time.deltaTime);
    }

    void Idle_ExitState()
    {
        // Run once when we exit the idle state
    }

    void Walk_SuperUpdate()
    {
        if (input.Current.JumpInput)
        {
            currentState = PlayerStates.Jump;
            return;
        }

        if (!MaintainingGround())
        {
            currentState = PlayerStates.Fall;
            return;
        }

        if (input.Current.MoveInput != Vector3.zero)
        {
            moveDirection = Vector3.MoveTowards(moveDirection, LocalMovement() * WalkSpeed, WalkAcceleration * Time.deltaTime);
        }
        else
        {
            currentState = PlayerStates.Idle;
            return;
        }
    }

    void Jump_EnterState()
    {
        controller.DisableClamping();
        controller.DisableSlopeLimit();

        moveDirection += Vector3.up * CalculateJumpSpeed(JumpHeight, Gravity);
    }

    void Jump_SuperUpdate()
    {
        Vector3 planarMoveDirection = Math3d.ProjectVectorOnPlane(Vector3.up, moveDirection);
        Vector3 verticalMoveDirection = moveDirection - planarMoveDirection;

        if (AcquiringGround())
        {
            moveDirection = planarMoveDirection;
            currentState = PlayerStates.Idle;
            return;            
        }

        planarMoveDirection = Vector3.MoveTowards(planarMoveDirection, LocalMovement() * WalkSpeed, JumpAcceleration * Time.deltaTime);
        verticalMoveDirection -= Vector3.up * Gravity * Time.deltaTime;

        moveDirection = planarMoveDirection + verticalMoveDirection;
    }

    void Fall_EnterState()
    {
        controller.DisableClamping();
        controller.DisableSlopeLimit();
    }

    void Fall_SuperUpdate()
    {
        if (AcquiringGround())
        {
            moveDirection = Math3d.ProjectVectorOnPlane(Vector3.up, moveDirection);
            currentState = PlayerStates.Idle;
            return;
        }

        moveDirection -= Vector3.up * Gravity * Time.deltaTime;
    }
}
