using UnityEngine;
using System.Collections;

public class PlayerHolder : MonoBehaviour 
{
	private float rotateSpeed;
	private bool InTheTrigger;

	void Start()
	{
		rotateSpeed = 1000.0f;
	}

	// Applies an upwards force to all rigidbodies that enter the trigger.
	void OnTriggerStay(Collider other)
	{
		if (other.attachedRigidbody)
			other.attachedRigidbody.AddForce(Vector3.down * Time.deltaTime * rotateSpeed);        
	}


}

