using UnityEngine;
using System.Collections;

public class TurnMovingPlatform : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Moving Platform")
			other.gameObject.GetComponent<Rigidbody2D>().velocity = -other.gameObject.GetComponent<Rigidbody2D>().velocity;
	}
}
