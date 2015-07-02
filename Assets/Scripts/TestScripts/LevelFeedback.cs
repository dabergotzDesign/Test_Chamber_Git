using UnityEngine;
using System.Collections;

public class LevelFeedback : MonoBehaviour 
{
	public GameObject Image;
	private bool Animation = false;
	public bool playAnimation;

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			Animation = true;
			Image.GetComponent<Animation> ().Play();

		}
	}

	void OntriggerExit(Collider collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
