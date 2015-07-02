using UnityEngine;
using System.Collections;

public class ResetLevel : MonoBehaviour 
{

	void Start()
	{
		GameVariables.checkpoint = new Vector3 ();
	}

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey (KeyCode.R) || Input.GetKey (KeyCode.Joystick1Button3))
		GameVariables.checkpoint = transform.position;

	}
}
