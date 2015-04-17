using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

    public float Distance = 5.0f;
    public float Height = 2.0f;

    public GameObject PlayerTarget;    

    private PlayerInputController input;
    private Transform target;
    private PlayerMachine machine;
    private float yRotation;

	// Use this for initialization
	void Start () {
        input = PlayerTarget.GetComponent<PlayerInputController>();
        machine = PlayerTarget.GetComponent<PlayerMachine>();
        target = PlayerTarget.transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = target.position;

        yRotation += input.Current.MouseInput.y;

        transform.rotation = Quaternion.LookRotation(machine.lookDirection, Vector3.up);
        transform.rotation *= Quaternion.AngleAxis(yRotation, Vector3.left);

        transform.position -= transform.forward * Distance;
        transform.position += Vector3.up * Height;
	}
}
