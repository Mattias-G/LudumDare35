using UnityEngine;
using System.Collections;

public class Raytracer : MonoBehaviour {

	Rigidbody2D playerBody;
	int lastFrame = -1;
	RaycastHit2D lastHit;

	void Start()
	{
		playerBody = gameObject.GetComponent<Rigidbody2D>();
	}

	public RaycastHit2D getRaycastToGround()
	{
		int currentFrame = Time.renderedFrameCount;
		if (currentFrame - lastFrame > 0)
		{
			lastFrame = currentFrame;
			int defaultLayer = 1 << LayerMask.NameToLayer("Default");
			RaycastHit2D hit = Physics2D.Raycast(playerBody.transform.position, Vector2.down, 100, defaultLayer);
			lastHit = hit;
			return hit;
		}
		return lastHit;
	}

	public bool isOnGround()
	{
		RaycastHit2D hit = getRaycastToGround();
		return hit.distance > 0 && hit.distance < gameObject.GetComponent<Renderer>().bounds.size.y / 2 + 0.1;
	}
}
