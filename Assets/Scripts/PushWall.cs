using System;
using UnityEngine;

public class PushWall : MonoBehaviour {
    public Transform WallA;
    public Transform WallB;
    public Transform WallC;
    public Transform WallD;

    private Vector3 wpos1;
    private Vector3 wpos2;
    private Vector3 wpos3;
    private Vector3 wpos4;
    public float speedo;
    private float timeScale = 0;
    private void Start () {
        wpos1 = WallA.position;
        wpos2 = WallB.position;
        wpos3 = WallC.position;
        wpos4 = WallD.position;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update () {
        timeScale += Time.deltaTime * speedo / 20;
        if (Mathf.Sin (timeScale) > -0.5f) {
            WallA.transform.localScale = new Vector3(50, 100, 28);
            WallB.transform.localScale = new Vector3(50, 100, 28);
            WallC.transform.localScale = new Vector3(50, 100, 28);
            WallD.transform.localScale = new Vector3(50, 100, 28);
            float x = Mathf.Sin (timeScale) * 6;

            WallA.position = new Vector3 (x + wpos1.x, wpos1.y, wpos1.z);
            WallB.position = new Vector3 (x + wpos2.x, wpos2.y, wpos2.z);
            WallC.position = new Vector3 (-x + wpos3.x, wpos3.y, wpos3.z);
            WallD.position = new Vector3 (-x + wpos4.x, wpos4.y, wpos4.z);
        } else if (Mathf.Sin (timeScale) > -0.7f){
            // for smoother transition
            WallA.transform.localScale = new Vector3(50, 100, 19);
            WallB.transform.localScale = new Vector3(50, 100, 19);
            WallC.transform.localScale = new Vector3(50, 100, 19);
            WallD.transform.localScale = new Vector3(50, 100, 19);
        } else {
            WallA.transform.localScale = new Vector3(50, 100, 10);
            WallB.transform.localScale = new Vector3(50, 100, 10);
            WallC.transform.localScale = new Vector3(50, 100, 10);
            WallD.transform.localScale = new Vector3(50, 100, 10);
        }
    }
}