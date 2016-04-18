using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Rigidbody2D playerRigidBody;


	// Use this for initialization
	void Start ()
    {
    }
	

	// Update is called once per frame
	void Update ()
    {
		if (playerRigidBody != null)
		{
			Vector3 position = playerRigidBody.transform.position;
			transform.position = new Vector3(position.x, position.y, transform.position.z);
		}
    }
}
