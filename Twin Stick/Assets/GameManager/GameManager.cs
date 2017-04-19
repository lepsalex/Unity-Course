using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    private float fixedDeltaTime;

    public bool recording = true;
    public bool paused = false;

    void Start () {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update () {
		if (CrossPlatformInputManager.GetButton("Fire1")) {
            recording = false;
        } else {
            recording = true;
        }

        if (Input.GetKeyDown(KeyCode.P) && !paused) {
            paused = true;
            PauseGame();
        } else if (Input.GetKeyDown(KeyCode.P) && paused) {
            paused = false;
            ResumeGame();
        }
    }

    void PauseGame() {
        Debug.Log("Paused");
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame () {
        Debug.Log("Resumed");
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
    }
}
