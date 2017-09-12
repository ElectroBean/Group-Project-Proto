﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject obj;
    public Camera cam;
    Vector3 pos = new Vector3(0, 0, 0);
    GameObject player;
    Vector3 translate = new Vector3(1, 0, 0);

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        translate *= 5 * Time.deltaTime;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(player.transform.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        if(pos.x >= 0.7f)
        {
            transform.Translate(translate);
        }
        if(pos.x <= 0.1 && cam.orthographicSize <= 10)
        {
            cam.fieldOfView += 1f;
        }


    }
}