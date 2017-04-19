using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

    public float panSpeed = 5f;

    private Vector3 armRotation;
    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update () {
        // Rotate around via the right stick
        armRotation.y += Input.GetAxis("RHoriz") * panSpeed * -1;
        armRotation.x += Input.GetAxis("RVert") * panSpeed;
        transform.rotation = Quaternion.Euler(armRotation);

        // Move with the player
        transform.position = player.transform.position;
	}
}
