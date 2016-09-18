using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    public LevelManager levelManager;

    void OnTriggerEnter2D (Collider2D collider) {
        print ("Trigger 2D");
        levelManager.LoadLevel("Win");
    }

    void OnCollisionEnter2D (Collision2D collision) {
        print ("Collision 2D");
    }
}
