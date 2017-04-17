using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 5f;
    public float distToRaise = 60f;
    public Rigidbody rigidBody;

    public void Awake () {
        rigidBody = GetComponent<Rigidbody>();
    }

    public bool IsStanding () {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationInEuler.x); // 270 is to comp for the -90 offset
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {
            return true; 
        } else {
            return false;
        }
    }

    public void RaiseIfStanding () {
        if (IsStanding()) {
            // Disable gravity
            rigidBody.useGravity = false;

            // Raise pin and reset rotation
            transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
    }

    public void Lower () {
        // Raise pin
        transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);

        // Re-enable gravity
        rigidBody.useGravity = true;
    }
}
