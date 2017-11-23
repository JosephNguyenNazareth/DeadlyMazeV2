using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingRunTime : MonoBehaviour {
    public GameObject Sound;
    public GameObject BGM;
    public Toggle Fullscreen;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void OnSoundChanged()
    {
        _MAINPLAYER.CurrentPlayer.Sound = Sound.GetComponent<Slider>().value;
    }

    public void OnBGMChanged()
    {
        _MAINPLAYER.CurrentPlayer.Sound = BGM.GetComponent<Slider>().value;
    }
    public void OnFullScreenChanged()
    {
        Screen.fullScreen = Fullscreen.GetComponent<Toggle>().IsActive();
    }
}
