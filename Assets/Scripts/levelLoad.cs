using UnityEngine;
using System.Collections;

public class levelLoad : MonoBehaviour 
{
	
	// Use this for initialization
	void OnTriggerEnter (Collider other) 
	{
		if (Application.GetStreamProgressForLevel ("GLD_LoadingScreenLevel02") == 1)
		{
			int i = Application.loadedLevel;
			Application.LoadLevel(i + 1);
		
		}
	}
	
}
