using UnityEngine;
using System.Collections;

public class PlayerMovementControls : MonoBehaviour
{
	[Range(0f, 25f)]
    public float MovementForce = 15.5f;
    [Range(0f, 25f)]
    public float MaxMovementSpeed = 7;
	[Range(0f, 1f)]
	public float AirControl = 0.8f;
	[Range(0f, 25f)]
	public float Friction = 10f;

	Rigidbody2D playerBody;
	Animator animator;
	Raytracer raytracer;

    // Use this for initialization
    void Start ()
    {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
		raytracer = gameObject.GetComponent<Raytracer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

	void FixedUpdate()
	{
		float playerMovementDir = Input.GetAxisRaw("Horizontal");
		float friction = Friction;
		
		float playerMovementForce = playerMovementDir * MovementForce;
		if (raytracer.isOnGround())
		{
			//Debug.Log("On the Ground");
		}
		else
		{
			playerMovementForce *= AirControl;
			friction *= AirControl/2;
			//Debug.Log("In the Air");
		}

        bool isSpeedTooHighInMovementDirection =
            playerMovementForce < 0 && playerBody.velocity.x <= -MaxMovementSpeed ||
            playerMovementForce > 0 && playerBody.velocity.x >= MaxMovementSpeed;
        if (!isSpeedTooHighInMovementDirection)
		    playerBody.AddForce(new Vector2(playerMovementForce, 0));
		
		if (playerMovementDir == 0)
		{
			animator.SetTrigger("Stop");
			if (Mathf.Abs(playerBody.velocity.x) > 0.001)
				playerBody.AddForce(new Vector2(-Mathf.Sign(playerBody.velocity.x) * friction, 0));
			else
				playerBody.velocity = new Vector2(0,playerBody.velocity.y);
		}
		else
		{
			animator.SetTrigger("Run");
			gameObject.GetComponent<SpriteRenderer>().flipX = playerMovementDir < 0;
		}
	}
}
