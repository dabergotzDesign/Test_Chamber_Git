using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour 
{
	bool collided;

	void Start ()
	{

	}

	IEnumerator OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			collided = true;		
			yield return new WaitForSeconds(0.5f);
			if(collided)
			{
				other.transform.position = GameVariables.checkpoint;
			}
		} 

		else if (other.tag == "Puppet")
		{
			collided = true;
			yield return new WaitForSeconds(2);
			if(collided)
			{
				Destroy(other.gameObject);
			}
		}
	}
}
