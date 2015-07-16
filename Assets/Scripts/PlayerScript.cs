using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	//public bool grounded = true;
	public Transform groundcheck;
	public float jumpPower = 1;
	public float speed;

	private bool jump;
	public bool useTorque = true;
	public const float groundRayLength = 1f;

	Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
	{
		rigidbody = GetComponent<Rigidbody> ();
		GameVariables.checkpoint = new Vector3 ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		jump = Input.GetButton ("Jump");


		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);

		// Fall detection
		if (transform.position.y < -10)
		{

			transform.position = GameVariables.checkpoint;
		}
		if (Input.GetKey (KeyCode.R) || Input.GetKey (KeyCode.Joystick1Button3))
		{
			transform.position = GameVariables.checkpoint;
		}
	
		
	}

	private void FixedUpdate()
	{
		if (useTorque)
		{
			rigidbody.AddTorque(new Vector3(0, 0, 0) * jumpPower, ForceMode.VelocityChange);
		}
		else
		{
			//rigidbody.AddForce(speed * jumpPower);
		}
		
		if (Physics.Raycast(transform.position, -Vector3.up, groundRayLength) && jump)
		{
			rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Trap") 
		{
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
		}
		else 
		{
			gameObject.GetComponent<Renderer>().material.color = Color.white;
		}

	}


}
