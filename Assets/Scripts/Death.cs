using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	void Start()
	{
		GameVariables.checkpoint = new Vector3 ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			transform.position = GameVariables.checkpoint;
		}
	}
}
