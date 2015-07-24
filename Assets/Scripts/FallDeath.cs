using UnityEngine;
using System.Collections;

public class FallDeath : MonoBehaviour
{
	bool collided;
	
	
	IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
			{
				collided = true;		
				yield return new WaitForSeconds (0.3f);
				if (collided) {
					other.transform.position = GameVariables.checkpoint;
			}
		} 
	}
}
