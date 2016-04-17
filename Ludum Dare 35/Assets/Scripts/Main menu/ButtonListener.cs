using UnityEngine;
using System.Collections;

namespace mainmenu
{
    public class ButtonListener : MonoBehaviour
    {
        public void StartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerTest");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
