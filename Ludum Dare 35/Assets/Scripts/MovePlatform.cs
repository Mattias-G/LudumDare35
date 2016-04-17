using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour {

	public float initialHorizontalVelocity;
	public float initialVerticalVelocity;

	private Rigidbody2D body;

	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
		body.velocity = new Vector2(initialHorizontalVelocity, initialVerticalVelocity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
