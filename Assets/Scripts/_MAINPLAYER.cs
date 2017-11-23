using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _MAINPLAYER : MonoBehaviour {
    public static Player.Player CurrentPlayer = new Player.Player ();
    public Slider HealthBar;
    public Collider coli;
    public GameObject destroy;
    public Transform DeathCanvas;
    public Transform HUD;
    public Transform FinishCanvas;
    public Transform PauseCanvas;
    public Transform FPSController;
    public Transform FirstPerson;
    public Transform Gun;
    public Inventory inventory;
    private Vector3 rot1;
    private Vector3 rot2;
    public Text bullet_number;
	public GameObject MainPlayer;

    void Start () {
		MainPlayer = GameObject.Find ("FPSController");
        Inventory.ItemConsumed += OnConsumeItem;
        // audio
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 32;
    }

    private void OnConsumeItem (Item item) {

        for (int i = 0; i < item.itemAttributes.Count; i++) {
            if (item.itemAttributes[i].attributeName == "LargeFAK") {

                CurrentPlayer.SetHP (CurrentPlayer.GetHP () + (int) MyItem.MyItem._FirstAidKit.big);
                HealthBar.value = CurrentPlayer.GetHP ();
            } else if (item.itemAttributes[i].attributeName == "MediumFAK") {
                CurrentPlayer.SetHP (CurrentPlayer.GetHP () + (int) MyItem.MyItem._FirstAidKit.medium);
                HealthBar.value = CurrentPlayer.GetHP ();
            } else if (item.itemAttributes[i].attributeName == "LargeAmmo") {
                CurrentPlayer.PlayerGun.SetHGBullet (CurrentPlayer.PlayerGun.GetHGBullet () + (int) MyItem.MyItem._BulletPack.large);
                int tmp = _MAINPLAYER.CurrentPlayer.PlayerGun.GetHGBullet ();
                if (tmp > 40)
                    tmp = 40;

                bullet_number.text = tmp.ToString () + "/40";

            } else if (item.itemAttributes[i].attributeName == "MediumAmmo") {
                CurrentPlayer.PlayerGun.SetHGBullet (CurrentPlayer.PlayerGun.GetHGBullet () + (int) MyItem.MyItem._BulletPack.medium);
                int tmp = _MAINPLAYER.CurrentPlayer.PlayerGun.GetHGBullet ();
                if (tmp > 40)
                    tmp = 40;
                bullet_number.text = tmp.ToString () + "/40";
            } else if (item.itemAttributes[i].attributeName == "SmallAmmo") {
                CurrentPlayer.PlayerGun.SetHGBullet (CurrentPlayer.PlayerGun.GetHGBullet () + (int) MyItem.MyItem._BulletPack.small);
                int tmp = _MAINPLAYER.CurrentPlayer.PlayerGun.GetHGBullet ();
                if (tmp > 40)
                    tmp = 40;
                bullet_number.text = tmp.ToString () + "/40";
            }
        }
    }
    public AudioMixerSnapshot inShark;
    public AudioMixerSnapshot inWolf;

    public AudioMixerSnapshot inSpider;
    public AudioMixerSnapshot inTreasure;
    public AudioMixerSnapshot mainGround;
    public AudioMixerSnapshot hurt;
    public AudioMixerSnapshot inFinish;

    public float bpm = 128;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;

    void OnTriggerEnter (Collider other) {
        //neu dung do
        rot1 = FPSController.gameObject.transform.rotation.eulerAngles;
        rot2 = FirstPerson.gameObject.transform.rotation.eulerAngles;
        // audio mixer
        if (other.gameObject.CompareTag ("Spider")) {
            inSpider.TransitionTo (m_TransitionIn);
        } else if (other.gameObject.CompareTag ("Wolf")) {
            inWolf.TransitionTo (m_TransitionIn);
        } else if (other.gameObject.CompareTag ("RexShark")) {
            inShark.TransitionTo (m_TransitionIn);
        }
        if (other.gameObject.CompareTag ("Treasure")) {
            inTreasure.TransitionTo (m_TransitionIn);
        }
        if (other.gameObject.CompareTag ("FinishZone")) {
            inFinish.TransitionTo (m_TransitionIn);
        }
        //
        if (other.gameObject.CompareTag ("Spider") || other.gameObject.CompareTag ("Wolf") || other.gameObject.CompareTag ("RexShark")) {
            // hurt.TransitionTo (m_TransitionIn);
            CurrentPlayer.SetHP (CurrentPlayer.GetHP () - 5);
            HealthBar.value = CurrentPlayer.GetHP ();
            if (CurrentPlayer.GetHP () <= 0) {
                Destroy (destroy, 1);
                // show finish canvas and hide HUD canvas
                DeathCanvas.gameObject.SetActive (true);
                FreezeDeath ();
            }
        } else if (other.gameObject.CompareTag ("chuongngaivat")) {
            // hurt.TransitionTo (m_TransitionIn);
            CurrentPlayer.SetHP (CurrentPlayer.GetHP () - 5);
            HealthBar.value = CurrentPlayer.GetHP ();
            if (CurrentPlayer.GetHP () <= 0) {
                Destroy (destroy, 1);
                DeathCanvas.gameObject.SetActive (true);
                FreezeDeath ();
            }
        } else if (other.gameObject.CompareTag ("Wall")) {
            CurrentPlayer.SetHP (-5);
            HealthBar.value = CurrentPlayer.GetHP ();
            if (CurrentPlayer.GetHP () <= 0) {
                Destroy (destroy, 1);
                DeathCanvas.gameObject.SetActive (true);
                FreezeDeath ();
            }
        }
    }

    void OnTriggerExit (Collider other) {
        if (other.gameObject.CompareTag ("Spider") || other.gameObject.CompareTag ("Wolf") || other.gameObject.CompareTag ("RexShark") || other.gameObject.CompareTag ("Treasure") || other.gameObject.CompareTag ("FinishZone")) {
            mainGround.TransitionTo (m_TransitionOut);
        }
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update () {
        if (DeathCanvas.gameObject.activeInHierarchy) {
            FreezeDeath ();
        }
        if (Input.GetKeyDown (KeyCode.I)) {
            if (Gun.gameObject.activeInHierarchy) {
                // Inventory.gameObject.SetActive (false);
                Gun.gameObject.SetActive (false);
            } else {
                // Inventory.gameObject.SetActive (true);
                Gun.gameObject.SetActive (true);
            }
        }
    }
    void FreezeDeath () {
        Time.timeScale = 0;
        HUD.gameObject.SetActive (false);
        FinishCanvas.gameObject.SetActive (false);
        PauseCanvas.gameObject.SetActive (false);
        FPSController.gameObject.transform.eulerAngles = rot1;
        FirstPerson.gameObject.transform.eulerAngles = rot2;
    }
	/*void ContinueLastSave() {
		Application.Unload ();
		SceneManager.LoadScene (_MAINPLAYER.CurrentPlayer.GetScene ());
	}*/
}