using System.Collections;
using UnityEngine;

public class OpenGate : MonoBehaviour {
    public int Direction;
    private Vector3 offset;
    private Vector3 pos;
    void Start()
    {
        if (Direction == 0) offset = new Vector3(0,1,0);
        else if (Direction == 1) offset = new Vector3(0,-1,0);
        else if (Direction == 2) offset = new Vector3(1,0,0);
        else if (Direction == 3) offset = new Vector3(-1,0,0);
        else if (Direction == 4) offset = new Vector3(0,0,1);
        else if (Direction == 5) offset = new Vector3(0,0,-1);

        pos = transform.position;
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag ("key")){
            transform.position = pos + offset;
            pos = transform.position;
        }
    }
}