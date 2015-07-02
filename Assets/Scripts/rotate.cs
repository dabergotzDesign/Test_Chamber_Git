using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour 
{
	public float rotationSpeed = 35;

	void Update()
	{
		transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed, Space.World);
	}
}
