using UnityEngine;
using System.Collections;

public class ScreenLevel2 : MonoBehaviour
{
	IEnumerator Start()
	{
		if (Application.GetStreamProgressForLevel ("GLD_LoadingScreenLevel02") == 1)
		{
			yield return new WaitForSeconds(2);
			Application.LoadLevelAsync("GLD_Level02_Garden");
		}
	}

}
