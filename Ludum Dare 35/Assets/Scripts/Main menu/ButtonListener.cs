using UnityEngine;
using System.Collections;

public class ButtonListener : MonoBehaviour {
    
	public void startGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayerTest");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
