using UnityEngine;
using System.Collections;

public class HazardScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
		if (other.gameObject.tag == "Player")
			UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
	}

}
