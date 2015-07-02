using UnityEngine;
using System.Collections;

public class levelLoad : MonoBehaviour 
{
	
	// Use this for initialization
	void OnTriggerEnter (Collider other) 
	{
		int i = Application.loadedLevel;
		Application.LoadLevelAsync(i + 1);
		Debug.Log("loaded");
	}
	
}
