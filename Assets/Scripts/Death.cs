using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
	private Animator animator;
	bool collided;

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

	IEnumerator OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			animator.SetBool("shock",true);
			collided = true;
			yield return new WaitForSeconds(0.5f);
			if(collided)
			{
				other.transform.position = GameVariables.checkpoint;
			}
		}
	}

	void OntriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			collided = false;
			animator.SetBool ("shock",false);
		}
	}
}
