using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public static bool canShoot;

	[Range(5, 10)]
	public float MaxDistance = 9;
	[Range(0, 5)]
	public float MinDistance = 3;
	public float Cooldown = 0.5f;
	public float PowerModifier = 150;

	Rigidbody2D playerBody;

    bool wasMouseDownLastUpdate;
	float cooldown;
    
	void Start ()
    {
		playerBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
    
	void Update ()
    {
		if (cooldown > 0)
		{
			cooldown -= Time.deltaTime;
			canShoot = false;
		}

        bool mouseDown = Input.GetMouseButton(0);
        if (mouseDown)
        {
            if (!wasMouseDownLastUpdate && canShoot)
                Shoot();
            wasMouseDownLastUpdate = true;
        }
        else
        {
            wasMouseDownLastUpdate = false;
        }
	}

    private void Shoot()
    {
		canShoot = false;
		cooldown = Cooldown;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePosition);
        float x = pos.x - playerBody.position.x;
        float y = pos.y - playerBody.position.y;
        float angle = Mathf.Atan2(y, x);
        float distance = Mathf.Max(Mathf.Min(Mathf.Sqrt(x * x + y * y), MaxDistance), MinDistance);

		playerBody.velocity = new Vector2(0,0);
        playerBody.AddForce(new Vector2(Mathf.Cos(angle) * distance * PowerModifier, Mathf.Sin(angle) * distance * PowerModifier));
    }
}
