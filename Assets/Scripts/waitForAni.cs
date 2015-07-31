using UnityEngine;
using System.Collections;

public class waitForAni : MonoBehaviour 
{

	IEnumerator Start ()
	{
		yield return new WaitForSeconds (6);
		Application.LoadLevel ("GLD_Menu");
	}
}
