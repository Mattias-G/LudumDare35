using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour {

	public Texture2D fadeTexture;
	public float fadeTime = 1f;
	public string targetScene;

	bool isFadingOut = true;
	float fadeCounter;
	
	void Start () {
		DontDestroyOnLoad(gameObject);
	}

	void OnGUI()
	{
		fadeCounter += Time.deltaTime;

		float alpha = 1 - Mathf.Clamp01(Mathf.Abs(fadeCounter - fadeTime) / fadeTime);
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = -9;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

		
		if (isFadingOut)
		{
			if (fadeCounter > fadeTime)
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
				isFadingOut = false;
			}
		}
		else
		{
			if (fadeCounter > fadeTime*2)
			{
				Destroy(gameObject);
			}
		}
	}
}
