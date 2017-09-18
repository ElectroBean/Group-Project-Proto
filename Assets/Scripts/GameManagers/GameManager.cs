using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    GameObject Checkpoints;
    GameObject player;

	// Use this for initialization
	void Start () {
        Checkpoints = GameObject.FindGameObjectWithTag("Checkpoint");
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Camera.main.WorldToViewportPoint(player.transform.position).y <= 0)
        {
            Vector3 newT = Checkpoints.transform.position;
            newT.Set(Checkpoints.transform.position.x, Checkpoints.transform.position.y + 10, 0);
            player.transform.position = newT;
        }
	}
}
