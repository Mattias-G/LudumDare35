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

	public RaycastHit2D getDistanceToGround()
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
}
