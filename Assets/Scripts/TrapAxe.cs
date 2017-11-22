using UnityEngine;
using System.Collections;
using System;

public class TrapAxe : MonoBehaviour {
    public Transform Axe;
    public Transform Axe1;
    public Transform Axe2;
    /// <summary>
    /// Special tools for rotating the Axes
    /// </summary>
    private float timeCounter = 0;
    public float speed;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        timeCounter += Time.deltaTime * speed / 10;
        float z = Mathf.Sin(timeCounter) * speed / (1.5f);
        Axe.transform.Rotate (new Vector3 (0, 0, z) * Time.deltaTime * 2);
        Axe1.transform.Rotate (new Vector3 (0, 0, -z) * Time.deltaTime * 2);
        Axe2.transform.Rotate (new Vector3 (0, 0, z) * Time.deltaTime * 2);
    }
}