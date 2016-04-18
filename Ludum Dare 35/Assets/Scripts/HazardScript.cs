using UnityEngine;
using System.Collections;

public class HazardScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			var animator = other.gameObject.GetComponent<Animator>();
			animator.SetTrigger("Death");
			other.gameObject.GetComponent<PlayerTransformer>().canTransform = false;
		}
	}

}
