using UnityEngine;
using System.Collections;

namespace Thanksmenu
{
	public class ButtonListener : MonoBehaviour
	{
		public void OpenMainMenu()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("main_menu");
		}
	}
}