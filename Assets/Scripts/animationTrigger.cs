using UnityEngine;
using System.Collections;

public class animationTrigger : MonoBehaviour
{
	public GameObject Door;
	public bool playAnimation;
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			Door.GetComponent<Animation> ().Play ();
			Destroy(gameObject);
		}
	}
	
}
