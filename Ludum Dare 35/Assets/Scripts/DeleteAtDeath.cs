using UnityEngine;
using System.Collections;

public class DeleteAtDeath : StateMachineBehaviour {

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Destroy(animator.gameObject);

		string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
		UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
	}

}
