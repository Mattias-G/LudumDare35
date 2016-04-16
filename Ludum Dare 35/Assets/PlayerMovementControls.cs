using UnityEngine;
using System.Collections;

public class PlayerMovementControls : MonoBehaviour {

	[Range(0f, 25f)]
	public float MOVEMENT_SPEED;

	Rigidbody2D playerBody;
	Animator animator;

    // Use this for initialization
    void Start () {
		MOVEMENT_SPEED = 5f;
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
    }

	void FixedUpdate()
	{
		float playerMovementDir = Input.GetAxisRaw("Horizontal");
		playerBody.velocity = new Vector2(playerMovementDir * MOVEMENT_SPEED, playerBody.velocity.y);
		if (playerMovementDir == 0)
		{
			animator.SetTrigger("Stop");
		}
		else
		{
			animator.SetTrigger("Run");
			gameObject.GetComponent<SpriteRenderer>().flipX = playerMovementDir < 0;
		}
	}
}
