using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

	public string NextLevel;

	void OnTriggerEnter2D(Collider2D collider)
	{
		enterGoal(collider.gameObject);
	}

	void OnCollision2D(Collision2D collision)
	{
		enterGoal(collision.gameObject);
	}

	void enterGoal(GameObject other)
	{
		if (gameObject.tag == "Player")
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(NextLevel);
		}
	}
}
