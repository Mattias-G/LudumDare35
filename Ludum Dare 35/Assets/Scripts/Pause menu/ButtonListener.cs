using UnityEngine;
using System.Collections;

namespace Pausemenu {
	public class ButtonListener : MonoBehaviour
	{
		void Start()
		{
			Time.timeScale = 0;
			SetComponentStates(false);
		}


		void Update()
		{
			bool closePauseMenu = Input.GetButtonDown("Cancel");
			if (closePauseMenu)
				ResumeGame();
		}


		public void ResumeGame()
		{
			Time.timeScale = 1;
			SetComponentStates(true);
			Destroy(gameObject);
		}

		public void OpenMainMenu()
		{
			Time.timeScale = 1;
			UnityEngine.SceneManagement.SceneManager.LoadScene("main_menu");
		}

		public void ExitGame()
		{
			Application.Quit();
		}

		private void SetComponentStates(bool areEnabled)
		{
			var player = GameObject.FindGameObjectWithTag("Player");
			if (player == null)
			{
				Debug.LogError("Didn't find any player!");
			}
			else
			{
				foreach (MonoBehaviour behaviour in player.GetComponents<MonoBehaviour>())
				{
					behaviour.enabled = areEnabled;
				}
			}
		}
	}
}
