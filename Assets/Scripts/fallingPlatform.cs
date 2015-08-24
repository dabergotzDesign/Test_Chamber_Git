using UnityEngine;
using System.Collections;

public class fallingPlatform : MonoBehaviour
{

	private Vector3 startPosition;
	private Quaternion startRotation;

		bool isFalling = false;
		bool isKinematic = true;
 		float downSpeed = 0;
	
	// checked the position
	void Start()
	{
		startPosition = transform.position;
		startRotation = transform.rotation;
	}

	// check if the player enters the object
	void OnTriggerEnter (Collider collide)
	{
		if (collide.gameObject.name == "Player")
		{
			gameObject.GetComponent<Renderer> ().material.color = new Color (0.7f, 0.1f, 0.1f, 0);
			isFalling = true;
		}

	}

	// gives the material the normal color
	void OnTriggerExit (Collider collide)
	{
		gameObject.GetComponent<Renderer> ().material.color = new Color (1, 1, 1, 0);
	}

	
	// starts the fall
	void Update () 
	{
		if (isFalling)
		{
			downSpeed += Time.deltaTime/75;
			transform.position = new Vector3(transform.position.x,
          	transform.position.y-downSpeed, transform.position.z);

			// Fall detection
			if (transform.position.y < -5)
			{
				//Destroy(gameObject);
				DestroyAndReset();
			}

		}

	}

	// resets the object
	public void DestroyAndReset()
	{
		transform.position = startPosition;
		transform.rotation = startRotation;
		isFalling = false;
	}
}
