using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

    void OnTriggerExit (Collider other) {
        GameObject target = other.gameObject;

        if (target.GetComponent<Pin>()) {
            Destroy(target);
        }
    }

}
