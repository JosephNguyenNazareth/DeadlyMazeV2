using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UsernameInput : MonoBehaviour {
    public Button Confirming;
    public InputField Input;
    void OnConfirmClicked()
    {
        if(Input.text != "" || Input.text != null)
        {
            _MAINPLAYER.CurrentPlayer.PlayerName = Input.text;
            Player.SaveDataProcessing.Save(ref _MAINPLAYER.CurrentPlayer);
            SceneManager.UnloadSceneAsync("UsernameInput");
            SceneManager.LoadScene(_MAINPLAYER.CurrentPlayer.GetScene());
        }
    }
}
