using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

	void OnTriggerEnter2D () {
        // Ensure that the level has not already be won
        if (!GameTimer.userWon) {
            levelManager.LoadLevel("03b Lose");
        }
    }
}
