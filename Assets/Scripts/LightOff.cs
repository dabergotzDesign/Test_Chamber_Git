using UnityEngine;

public class LightOff : MonoBehaviour
{
	public Light PointLightObject;
	public bool LightEnabled;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Trap") {
			LightEnabled = !LightEnabled;
			PointLightObject.enabled = LightEnabled;
		}
		else
		{
			LightEnabled = true;
		}
	}
}
