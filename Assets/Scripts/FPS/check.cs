﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour {
    public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (obj.activeSelf == false)
            obj.SetActive(true);
	}
}