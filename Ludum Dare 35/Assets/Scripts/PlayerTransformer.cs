﻿using UnityEngine;
using System.Collections;

public class PlayerTransformer : MonoBehaviour
{
    public int triggerMouseButton;
    public Transform playerToTurnInto;
	public bool canTransform;

    // Use this for initialization
    void Start ()
	{
		canTransform = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool mouseDown = Input.GetMouseButtonDown(triggerMouseButton);
		if (mouseDown && canTransform)
		{
            var previousVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
			var playerMovementDir = Input.GetAxisRaw("Horizontal");

			Destroy(gameObject);
            var newObject = (Transform)Instantiate(playerToTurnInto, gameObject.transform.position, Quaternion.identity);
            var body = newObject.gameObject.GetComponent<Rigidbody2D>();
            var camera = Camera.main.GetComponent<CameraMovement>();
            camera.playerRigidBody = body;

            body.velocity = previousVelocity;

			var animator = newObject.gameObject.GetComponent<Animator>();
			animator.SetTrigger("Transform");

			newObject.GetComponent<SpriteRenderer>().flipX = playerMovementDir < 0;
		}
	}
}
