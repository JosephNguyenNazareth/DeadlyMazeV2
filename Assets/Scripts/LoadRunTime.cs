using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadRunTime : MonoBehaviour {
    public Button[] LoadButton = new Button[10];
    public Text[] ButtonText = new Text[10];
    static string[] Name = Player.SaveDataProcessing.GetSaveDataName(); //Get file names
    Player.Player[] SavedPlayer = new Player.Player[Name.Length]; //Get Players
    public GameObject MainController;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < Name.Length; i++)
        {
            SavedPlayer[i] = Player.SaveDataProcessing.Load(Name[i].Substring(0, Name[i].Length - 4));
            ButtonText[i].text = "Name: " + SavedPlayer[i].PlayerName + "\nScene: " + SavedPlayer[i].GetScene() + "\n";
        }
        for (int i = Name.Length; i < 10; i++)
            ButtonText[i].text = "";
        MainController.transform.position = new Vector3(_MAINPLAYER.CurrentPlayer.x, _MAINPLAYER.CurrentPlayer.y, _MAINPLAYER.CurrentPlayer.z);
    }
	
	// Update is called once per frame
	void Update () {
	}
    public void LoadGame(int i)
    {
        _MAINPLAYER.CurrentPlayer = SavedPlayer[i];
        Application.Unload();
        SceneManager.LoadScene(_MAINPLAYER.CurrentPlayer.GetScene());
    }

}
