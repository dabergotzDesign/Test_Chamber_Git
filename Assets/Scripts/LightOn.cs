using UnityEngine;

public class LightOn : MonoBehaviour
{
	public GameObject point_light;
	public AudioClip clip;

	void Start()
	{
		point_light.active = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			AudioSource.PlayClipAtPoint(clip,new Vector3());	
			point_light.active = true;
		}
	}
}
