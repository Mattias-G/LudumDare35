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

        void SetComponentStates(bool areEnabled)
        {
            var player = GameObject.Find("player_human");
            if (player == null)
                player = GameObject.Find("player_ball");
            foreach (MonoBehaviour behaviour in player.GetComponents<MonoBehaviour>())
            {
                behaviour.enabled = areEnabled;
            }
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
    }
}
