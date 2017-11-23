using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
	public void GoToScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}
	public void BackToGame (string sceneName) {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (sceneName);
		}
	}
}