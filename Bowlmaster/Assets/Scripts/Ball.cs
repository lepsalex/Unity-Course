using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Vector3 startPosition;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

        startPosition = transform.position;

        audioSource = GetComponent<AudioSource>(); 
    }

    public void Launch (Vector3 velocity) {
        inPlay = true;

        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;

        audioSource.Play();
    }

    public void Reset () {
        inPlay = false;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;

        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
    }
}
