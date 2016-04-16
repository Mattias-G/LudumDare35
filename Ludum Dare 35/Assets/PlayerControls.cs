using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public float MOVEMENT_SPEED;
	public float JUMP_SPEED;

	Rigidbody2D playerBody;
	bool pressedJump;

	// Use this for initialization
	void Start () {
		MOVEMENT_SPEED = 5f;
		JUMP_SPEED = 6f;
		playerBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		pressedJump = Input.GetButtonDown("Jump");
	}

	void FixedUpdate()
	{
		float playerMovementDir = Input.GetAxisRaw("Horizontal");
		playerBody.velocity = new Vector2(playerMovementDir * MOVEMENT_SPEED, playerBody.velocity.y);

		int defaultLayer = 1 << LayerMask.NameToLayer ("Default");
		if (pressedJump && playerBody.IsTouchingLayers(defaultLayer))
		{
			playerBody.velocity += Vector2.up * JUMP_SPEED;
		}
	}
}
