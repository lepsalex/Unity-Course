using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingDisplay;
    public GameObject pinSet;
    
    private bool ballOutOfPlay = false;
    private float lastChangeTime;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;

    private ActionMaster actionMaster = new ActionMaster();

    private Ball ball;
    private Animator animator;

    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay) {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
	}

    void UpdateStandingCountAndSettle() {
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
        // Use actionMaster to control what happens next ...
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        ActionMaster.Action action = actionMaster.Bowl(pinFall);

        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("End Game Undefined!");
        }

        // Reset ball position
        ball.Reset();

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

    public int SetBallOutOfPlay() {
        ballOutOfPlay = true;
    }

    public void RaisePins() {
        // raise standing pins only by distance (distanceToRaise)
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.RaiseIfStanding();
        }

        // Reset UI text colour
        standingDisplay.color = Color.grey;
    }

    public void LowerPins() {
        // raise standing pins only by distance (distanceToRaise)
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
        }

        // Reset UI text colour
        standingDisplay.color = Color.grey;
    }

    public void RenewPins () {
        GameObject newPins = Instantiate(pinSet);

        // Disable gravty for each of them (will be enabled by lower method)
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.rigidBody.useGravity = false;
        }

        // Move pins to raised position
        newPins.transform.position += new Vector3(0, 60f, 0);

        // Reset UI text colour
        standingDisplay.color = Color.grey;
    }
}
