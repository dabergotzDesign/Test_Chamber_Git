using UnityEngine;
using System.Collections;

public class ScreenLevel1 : MonoBehaviour
{
	IEnumerator Start()
	{
		if (Application.GetStreamProgressForLevel ("GLD_LoadingScreenLevel01") == 1)
		{
			yield return new WaitForSeconds(2);
			Application.LoadLevel("GLD_Level01_House");
		
		}
	}

}
