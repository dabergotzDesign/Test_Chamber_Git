using UnityEngine;
using System.Collections;

public class FallDeath : MonoBehaviour
{
	bool collided;
	public AudioClip clip;
	
	IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
			{
				AudioSource.PlayClipAtPoint(clip, new Vector3());	
				collided = true;		
				yield return new WaitForSeconds (0.3f);
				if (collided) {
					other.transform.position = GameVariables.checkpoint;
			}
		} 
	}
}
