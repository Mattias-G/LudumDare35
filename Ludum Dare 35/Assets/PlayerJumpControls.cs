using UnityEngine;
using System.Collections;

public class PlayerJumpControls : MonoBehaviour {

	[Range(0f, 25f)]
	public float JUMP_SPEED;

	Rigidbody2D playerBody;
	Animator animator;
	bool pressedJump;
	bool releasedJump;

	// Use this for initialization
	void Start () {
		JUMP_SPEED = 8f;
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!pressedJump)
		{
			pressedJump = Input.GetButtonDown("Jump");
			releasedJump = false;
		}
		if (!releasedJump)
			releasedJump = Input.GetButtonUp("Jump");

		if (playerBody.velocity.y < 0)
		{
			animator.ResetTrigger("Land");
			animator.SetTrigger("Fall");
		}
	}

	void FixedUpdate()
	{
		int defaultLayer = 1 << LayerMask.NameToLayer("Default");
		RaycastHit2D hit = Physics2D.Raycast(playerBody.transform.position, Vector2.down, 100, defaultLayer);
		if (hit.distance > gameObject.GetComponent<Renderer>().bounds.size.y / 2 + 0.2)
		{
			//	animator.ResetTrigger("Fall");
			animator.SetTrigger("Jump");
		}

		Debug.Log("Jump: " + hit.distance + " : " + (gameObject.GetComponent<Renderer>().bounds.size.y / 2 + 0.1));
		if (hit.distance <= gameObject.GetComponent<Renderer>().bounds.size.y / 2 + 0.1)
		{
			if (pressedJump)
			{
				pressedJump = false;
				animator.ResetTrigger("Fall");
				animator.SetTrigger("Jump");
				playerBody.velocity += Vector2.up * JUMP_SPEED;
			}
			animator.ResetTrigger("Jump");
			animator.SetTrigger("Land");
		}

		if (releasedJump)
		{
			releasedJump = false;
			if (playerBody.velocity.y > 0)
				playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y / 2);
		}
	}
}
