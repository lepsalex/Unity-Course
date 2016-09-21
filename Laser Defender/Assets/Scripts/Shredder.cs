using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    // Destroy and game objects that touch this
    void OnTriggerEnter2D (Collider2D col) {
        Destroy(col.gameObject);
    }
}
