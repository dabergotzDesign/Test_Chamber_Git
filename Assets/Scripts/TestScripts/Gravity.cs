using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour 
{
	public static Vector3 gravity; 

	void FixedUpdate()
	{
		Physics.gravity = new Vector3 (0, -40.0f, 0);
	}
}
