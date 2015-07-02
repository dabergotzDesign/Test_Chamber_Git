using UnityEngine;
using System.Collections;

public class ParticleTrigger : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().Stop();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Trap") {
			GetComponent<ParticleSystem> ().Play ();
		}
		else
		{
			GetComponent<ParticleSystem>().Stop();
		}
	}

}
