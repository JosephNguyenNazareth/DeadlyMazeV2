using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingRunTime : MonoBehaviour {
    public GameObject Sound;
    public GameObject BGM;
	public AudioMixer MusicPlayer;
	public Transform SettingCanvas;
	public Transform CreditCanvas;
    public Toggle Fullscreen;

    public void OnSoundChanged()
    {
        _MAINPLAYER.CurrentPlayer.Sound = Sound.GetComponent<Slider>().value;
    }

    public void OnBGMChanged()
    {
        _MAINPLAYER.CurrentPlayer.BGM = BGM.GetComponent<Slider>().value;
		MusicPlayer.SetFloat ("MusicPlayer", _MAINPLAYER.CurrentPlayer.BGM);
    }
    public void OnFullScreenChanged()
    {
        Screen.fullScreen = Fullscreen.GetComponent<Toggle>().IsActive();
    }
	public void Credit() {
		if (SettingCanvas.gameObject.activeInHierarchy) {
			SettingCanvas.gameObject.SetActive (false);
			CreditCanvas.gameObject.SetActive (true);
		}
	}
}
