using UnityEngine;
using System.Collections;

public class ResetObject : MonoBehaviour
{
	private Vector3 startPosition;
	private Quaternion startRotation;


	// Use this for initialization
	void Start ()
	{
		startPosition = transform.position;
		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void detectFall ()
	{
		// Fall detection
		if (transform.position.y < -5)
		{
			//Destroy(gameObject);
			DestroyAndReset();
		}
	}

	public void DestroyAndReset()
	{
		transform.position = startPosition;
		transform.rotation = startRotation;
	}
}
