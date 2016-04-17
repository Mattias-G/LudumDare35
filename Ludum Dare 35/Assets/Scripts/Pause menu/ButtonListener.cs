using UnityEngine;
using System.Collections;

namespace Pausemenu {
    public class ButtonListener : MonoBehaviour
    {
        void Start()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
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
    }
}
