using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject obj;
    public Camera cam;
    Vector3 pos = new Vector3(0, 0, 0);
    GameObject player;
    Vector3 translate = new Vector3(1, 0, 0);
    public float transSpeed;
    public float fovSpeed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        translate *= transSpeed * Time.deltaTime;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(player.transform.position);
        transSpeed = player.GetComponent<CharacterControls>().speed;
        //translate *= transSpeed * Time.deltaTime;
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        if (pos.x >= 0.5f)
        {
            transform.Translate(translate);
        }
        if(pos.x <= 0.1 && cam.orthographicSize <= 25)
        {
            cam.orthographicSize += fovSpeed;
        }
        if (pos.x >= 0.4 && cam.orthographicSize >= 15)
        {
            cam.orthographicSize -= 1f;
        }


    }
}
