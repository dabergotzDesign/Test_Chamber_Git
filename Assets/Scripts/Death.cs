using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	private Animator animator;

	void Awake()
	{
		animator = GetComponent<Animator> ();
	}

	void Start()
	{

		GameVariables.checkpoint = new Vector3 ();
	}

	void Update()
	{

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			animator.SetBool("shock",true);
			other.transform.position = GameVariables.checkpoint;
		}
	}

	void OntriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			animator.SetBool ("shock",false);
		}
	}
}
