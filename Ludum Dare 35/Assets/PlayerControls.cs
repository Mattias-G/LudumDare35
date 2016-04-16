using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	[Range(0f, 25f)]
	public float MOVEMENT_SPEED;
	[Range(0f, 25f)]
	public float JUMP_SPEED;

	Rigidbody2D playerBody;
    bool pressedJump;
    bool releasedJump;

    // Use this for initialization
    void Start () {
		MOVEMENT_SPEED = 5f;
		JUMP_SPEED = 8f;
		playerBody = gameObject.GetComponent<Rigidbody2D>();
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
    }

	void FixedUpdate()
	{
		float playerMovementDir = Input.GetAxisRaw("Horizontal");
		playerBody.velocity = new Vector2(playerMovementDir * MOVEMENT_SPEED, playerBody.velocity.y);

		if (pressedJump)
		{
            pressedJump = false;
			int defaultLayer = 1 << LayerMask.NameToLayer("Default");
			RaycastHit2D hit = Physics2D.Raycast(playerBody.transform.position, Vector2.down, 100, defaultLayer);
			Debug.Log("Jump: " + hit.distance + " : " + (gameObject.GetComponent<Renderer>().bounds.size.y / 2 + 0.1));
			if (hit.distance <= gameObject.GetComponent<Renderer>().bounds.size.y / 2 + 0.1)
			{
				playerBody.velocity += Vector2.up * JUMP_SPEED;
			}
		}

        if (releasedJump)
        {
            releasedJump = false;
            if (playerBody.velocity.y > 0)
                playerBody.velocity = new Vector2(playerBody.velocity.x,playerBody.velocity.y/2);
        }
	}
}
