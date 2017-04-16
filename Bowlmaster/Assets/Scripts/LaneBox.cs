using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour {

    private PinSetter pinSetter;

	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
    }

    void OnTriggerExit (Collider other) {
        GameObject target = other.gameObject;
        
        if (target.GetComponent<Ball>()) {
            pinSetter.SetBallOutOfPlay();
        }
    }
}
