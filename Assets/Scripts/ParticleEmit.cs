using UnityEngine;
using System.Collections;

public class ParticleEmit : MonoBehaviour
{
	void Start () {
		GetComponent<ParticleSystem>().Stop();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Fireball")
		{
			GetComponent<ParticleSystem> ().Play ();
		}
		else
		{
			GetComponent<ParticleSystem> ().Stop ();
		}

	}
}
