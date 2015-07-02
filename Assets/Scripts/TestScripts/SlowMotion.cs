using UnityEngine;
using System.Collections;

public class SlowMotion : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (Time.timeScale == 1.0F)
				Time.timeScale = 0.7F;
			else
				Time.timeScale = 1.0F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
		}
	}
}

