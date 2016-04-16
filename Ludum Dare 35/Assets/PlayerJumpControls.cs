using UnityEngine;
using System.Collections;

public class PlayerJumpControls : MonoBehaviour {

	[Range(0f, 25f)]
	public float JUMP_SPEED = 8;

	Rigidbody2D playerBody;
	Animator animator;
	Raytracer raytracer;
	bool pressedJump;
	bool releasedJump;

	// Use this for initialization
	void Start () {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
		raytracer = gameObject.GetComponent<Raytracer>();
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
		RaycastHit2D hit = raytracer.getDistanceToGround();
		if (hit.distance > gameObject.GetComponent<Renderer>().bounds.size.y / 2 + 0.2)
		{
			//	animator.ResetTrigger("Fall");
			animator.SetTrigger("Jump");
		}

        if (pressedJump)
        {
            pressedJump = false;
            if (hit.distance <= gameObject.GetComponent<Renderer>().bounds.size.y / 2 + 0.1)
            {
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
