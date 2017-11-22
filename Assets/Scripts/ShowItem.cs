using System;
using UnityEngine;

public class ShowItem : MonoBehaviour {
    public Transform Gun;
    public Transform GunImage;
    float render = 0;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update () {
        render += Time.deltaTime;
        if (Input.GetKeyDown (KeyCode.I)) {
            if (Gun.gameObject.activeInHierarchy) {
                Gun.gameObject.SetActive (false);
                GunImage.gameObject.SetActive (false);
            } else {
                Gun.gameObject.SetActive (true);
                GunImage.gameObject.SetActive (true);
            }
        }
        if (render > 10f) {
            if (Gun.gameObject.activeInHierarchy) {
                Gun.gameObject.SetActive (false);
                GunImage.gameObject.SetActive (false);
            }
            render = 0;
        }
    }
}