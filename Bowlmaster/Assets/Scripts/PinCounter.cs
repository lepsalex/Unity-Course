using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    private GameManager gameManager;
    private bool ballOutOfPlay = false;
    private float lastChangeTime;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;

    public Text standingDisplay;

    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay) {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    void OnTriggerExit (Collider other) {
        GameObject target = other.gameObject;

        if (target.GetComponent<Ball>()) {
            ballOutOfPlay = true;
        }
    }

    public void Reset() {
        lastSettledCount = 10;
    }

    void UpdateStandingCountAndSettle () {
        // Update the lastStandingCount
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount) {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // 3s settling time

        // Call PinsHaveSettled if no change in settleTime
        if (Time.time - lastChangeTime > settleTime) {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled () {
        // Use actionMaster to control what happens next ...
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        // Call GameManager
        gameManager.Bowl(pinFall);

        // Pins have settled and ball not back in box
        lastStandingCount = -1;
        ballOutOfPlay = false;

        // Update text to show frame is over
        standingDisplay.color = Color.green;
    }

    public int CountStanding () {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                standing++;
            }
        }

        return standing;
    }
}
