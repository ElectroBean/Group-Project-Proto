using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    GameObject player;
    bool toggled = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= gameObject.transform.position.x)
        {
            if (toggled == false)
            {
                gameObject.transform.Rotate(new Vector3(0, 180, 0));
                toggled = true;
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    gameObject.transform.Rotate(new Vector3(0, 180, 0));
    //}
}
