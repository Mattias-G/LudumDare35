using UnityEngine;
using System.Collections;

namespace mainmenu
{
    public class ButtonListener : MonoBehaviour
    {
        public void StartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("level1");
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
