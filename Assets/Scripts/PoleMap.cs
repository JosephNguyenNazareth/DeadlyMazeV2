using System;
using System.Collections;
using UnityEngine;

public class PoleMap : MonoBehaviour {
    /// <summary>
    /// PoleMapPanel hold the panel on screen which shows the position of poles that we've used.
    /// Tha pole map will show the position of the player either.
    /// </summary>
    public Transform PoleMapPanel;
    public Transform Player;
    public Transform PlayerDot;
    private Vector3 PlayerPosition;
    private Vector3 offset;
    /// <summary>
    /// At first, the position of player is recorded
    /// </summary>
    void Start () {
        offset = new Vector3(PlayerDot.position.x + 5, PlayerDot.position.y , 0.0f);
    }
    /// <summary>
    /// Each time pressed the 'Tab' button, the map appears.
    /// Otherwise, it hides.
    /// The dot presents the player will move with the player on the map area, although it hides.
    /// </summary>
    void Update () {
        if (Input.GetKeyDown (KeyCode.P)) {
            if (!PoleMapPanel.gameObject.activeInHierarchy)
                PoleMapPanel.gameObject.SetActive (true);
            else PoleMapPanel.gameObject.SetActive (false);
        }
        ShowPlayerPosition ();
    }
    void ShowPlayerPosition () {
        PlayerPosition.Set(- Player.position.z / 5, Player.position.x / 5, 0.0f);
        PlayerDot.transform.position = PlayerPosition + offset;
    }
}