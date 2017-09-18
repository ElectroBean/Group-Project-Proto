﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    bool rocket = false;
    public GameObject rocketPrefab;
    Vector3 pos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y, gameObject.transform.position.z);
		if(Input.GetKeyDown(KeyCode.F) && rocket)
        {
            Instantiate(rocketPrefab, pos, new Quaternion(0, 0, 0, 0));
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
