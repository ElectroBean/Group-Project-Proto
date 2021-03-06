﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class RocketScript : MonoBehaviour {

    bool rocket = false;
    public GameObject rocketPrefab;
    Vector3 pos;
    bool shot = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z);
        if(XCI.GetButtonDown(XboxButton.B) && rocket)
        {
            shot = true;
            Instantiate(rocketPrefab, pos, Quaternion.Euler(0, 0, 90));
        }
		if(Input.GetKeyDown(KeyCode.Space) && rocket)
        {
            Instantiate(rocketPrefab, pos, Quaternion.Euler(0, 0, 90));
        }
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Rocket")
        {
            rocket = true;
            Destroy(col.gameObject);
        }
    }
}
