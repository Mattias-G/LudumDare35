using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public string NextLevel;
	public Transform faderPrefab;

	void OnTriggerEnter2D(Collider2D collider)
	{
		enterGoal(collider.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		enterGoal(collision.gameObject);
	}

	void enterGoal(GameObject other)
	{
		if (other.tag == "Player")
		{
			Transform transform = (Transform)Instantiate(faderPrefab, Vector3.zero, Quaternion.identity);
			transform.gameObject.GetComponent<SceneFader>().targetScene = NextLevel;
		}
	}
}
