using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyShooterFlame : MonoBehaviour {
	public float t;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, t);
	}
	
	// Update is called once per frame
	void Update () {
		
}
}
