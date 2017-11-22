using System;
using System.Collections;
using UnityEngine;

public class TrapArrow : MonoBehaviour {
    /// <summary>
    /// Arrow series is a set of 3 packs of flying arrows
    /// contains Arrow, Arrow1 and Arrow 2
    /// </summary>
    public Transform Arrow;
    public Transform Arrow1;
    public Transform Arrow2;
    /// <summary>
    /// apos is the start position of arrow pack
    /// </summary>
    private Vector3 apos;
    private Vector3 apos1;
    private Vector3 apos2;
    /// <summary>
    /// speedo stands for base flying speed of the arrows
    /// </summary>
    public float speedo;
    /// <summary>
    /// range will define how far the arrow will fly
    /// </summary>
    public float range;
    /// <summary>
    /// 3 packs of arrows will fly with delta range
    /// which means it will render time between each flight
    /// </summary>
    public float deltaRange;
    private Vector3 offset;
    /// <summary>
    /// and get those arrow first positions
    /// later, when thos reach their range, they come back to these positions
    /// </summary>
    private void Start () {
        apos = Arrow.position;
        apos1 = Arrow1.position;
        apos2 = Arrow2.position;

        offset = new Vector3 (0.0f, 0.0f, speedo / 50);
    }
    /// <summary>
    /// render time between each flight will be defined in StartCoroutine
    /// </summary>
    void Update () {
        float UpdateRange = Math.Abs (Arrow.position.z - apos.z);
        if (UpdateRange < range)
            Arrow.position += offset;
        else  StartCoroutine ("WaitOneSeconds");

        float UpdateRange1 = Math.Abs (Arrow1.position.z - apos1.z);
        if (UpdateRange1 < range + deltaRange)
            Arrow1.position += offset;
        else StartCoroutine ("WaitOneSeconds1");

        float UpdateRange2 = Math.Abs (Arrow2.position.z - apos2.z);
        if (UpdateRange2 < range + 2 * deltaRange)
            Arrow2.position += offset;
        else StartCoroutine ("WaitOneSeconds2");
    }
    IEnumerator WaitOneSeconds () {
        yield return new WaitForSeconds (1);
        Arrow.position = apos;
    }
    IEnumerator WaitOneSeconds1() {
        yield return new WaitForSeconds (1);
        Arrow1.position = apos1;
    }
    IEnumerator WaitOneSeconds2 () {
        yield return new WaitForSeconds (1);
        Arrow2.position = apos2;
    }
}