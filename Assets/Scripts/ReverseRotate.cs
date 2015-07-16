using UnityEngine;
using System.Collections;

public class ReverseRotate : MonoBehaviour 
{
	public float rotationSpeed = 35;

	void Update()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	}
}
