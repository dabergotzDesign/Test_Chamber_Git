using UnityEngine;
using System.Collections;

public class fallingPlatform : MonoBehaviour
{
		bool isFalling = false;
 		float downSpeed = 0;
	

	// Use this for initialization
	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.name == "Player")
		{
			gameObject.GetComponent<Renderer>().material.color = new Color (0.7f, 0.1f, 0.1f,0);
			isFalling = true;
			Destroy (gameObject, 5);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isFalling)
		{
			downSpeed += Time.deltaTime/75;
			transform.position = new Vector3(transform.position.x,
          	transform.position.y-downSpeed, transform.position.z);
		}
	}
}
