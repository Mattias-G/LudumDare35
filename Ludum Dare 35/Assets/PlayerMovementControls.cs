using UnityEngine;
using System.Collections;

public class PlayerMovementControls : MonoBehaviour {
	
	[Range(0f, 25f)]
    public float MOVEMENT_SPEED = 5;
    [Range(0f, 25f)]
    public float MAX_MOVEMENT_SPEED = 7;
	[Range(0f, 1f)]
	public float AIR_CONTROL = 0.2f;

    Rigidbody2D playerBody;
	Animator animator;
	Raytracer raytracer;

    // Use this for initialization
    void Start () {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
		raytracer = gameObject.GetComponent<Raytracer>();
	}
	
	// Update is called once per frame
	void Update () {
    }

	void FixedUpdate()
	{
		float playerMovementDir = Input.GetAxisRaw("Horizontal");
		//playerBody.velocity = new Vector2(playerMovementDir * MOVEMENT_SPEED, playerBody.velocity.y);
		float playerMovementForce = playerMovementDir * MOVEMENT_SPEED;
		if (raytracer.isOnGround())
		{
			Debug.Log("On the Ground");
		}
		else
		{
			playerMovementForce *= 0.1f;
			Debug.Log("In the Air");
		}

		playerBody.AddForce(new Vector2(playerMovementForce, 0));
		playerBody.velocity = new Vector2(Mathf.Clamp(playerBody.velocity.x, -MAX_MOVEMENT_SPEED, MAX_MOVEMENT_SPEED), playerBody.velocity.y);
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
