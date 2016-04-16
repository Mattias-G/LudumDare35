using UnityEngine;
using System.Collections;

public class PlayerTransformer : MonoBehaviour
{
    public int triggerMouseButton;
    public Transform playerToTurnInto;

    // Use this for initialization
    void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool mouseDown = Input.GetMouseButtonDown(triggerMouseButton);
		if (mouseDown)
		{
            Destroy(gameObject);
            var newObject = (Transform)Instantiate(playerToTurnInto, gameObject.transform.position, Quaternion.identity);
            var body = newObject.gameObject.GetComponent<Rigidbody2D>();
            var camera = Camera.main.GetComponent<CameraMovement>();
            camera.playerRigidBody = body;
        }
	}
}
