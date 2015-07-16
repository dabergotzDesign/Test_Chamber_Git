using UnityEngine;

public class LightOn : MonoBehaviour
{
	public GameObject point_light;

	void Start()
	{
		point_light.active = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			point_light.active = true;
		}
	}
}
