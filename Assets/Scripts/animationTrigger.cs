using UnityEngine;
using System.Collections;

public class animationTrigger : MonoBehaviour
{
	public GameObject Door;
	public bool playAnimation;
	public AudioClip clip;
	
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Door.GetComponent<Animation> ().Play ();
			AudioSource.PlayClipAtPoint(clip, new Vector3());
			Destroy (gameObject);
		}

	}
	
}
