using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;

    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;

    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    void OnTriggerEnter (Collider other) {
        GameObject target = other.gameObject;

        // Ball enteres play box
        if (target.GetComponent<Ball>()) {
            OnBallEnter();
        }
    }

    void OnTriggerExit (Collider other) {
        GameObject target = other.gameObject;

        if (target.GetComponent<Pin>()) {
            Destroy(target);
        }
    }

    // Update is called once per frame
    void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox) {
            CheckStanding();
        }
	}

    void CheckStanding() {
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

    void PinsHaveSettled() {
        // Reset ball position
        ball.Reset();

        // Pins have settled and ball not back in box
        lastStandingCount = -1;
        ballEnteredBox = false;

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

    public void OnBallEnter () {
        ballEnteredBox = true;
        standingDisplay.color = Color.red;
    }

    public void RaisePins() {
        // raise standing pins only by distance (distanceToRaise)
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins() {
        // raise standing pins only by distance (distanceToRaise)
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }

    public void RenewPins () {
        Debug.Log("RENEW");
    }
}
