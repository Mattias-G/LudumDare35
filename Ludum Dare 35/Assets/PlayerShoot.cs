using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	[Range(5, 10)]
	public float MaxDistance = 9;
	[Range(0, 5)]
	public float MinDistance = 3;
	public float PowerModifier = 150;

	Rigidbody2D playerBody;

	// Use this for initialization
	void Start () {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			Vector3 pos = Camera.main.ScreenToWorldPoint(mousePosition);
			float x = pos.x - playerBody.position.x;
			float y = pos.y - playerBody.position.y;
			float angle = Mathf.Atan2(y, x);
			float distance = Mathf.Max(Mathf.Min(Mathf.Sqrt(x * x + y * y), MaxDistance), MinDistance);

			playerBody.AddForce(new Vector2(Mathf.Cos(angle) * distance * PowerModifier, Mathf.Sin(angle) * distance * PowerModifier));
		}
	}
}
