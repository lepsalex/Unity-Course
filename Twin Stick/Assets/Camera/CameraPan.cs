using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void LateUpdate () {
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update () {
        print("RHORIZ " + Input.GetAxis("RHoriz"));
        print("RVERT " + Input.GetAxis("RVert"));
    }
}
