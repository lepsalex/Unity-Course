using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

    public GameObject pinSet;

    private Animator animator;
    private PinCounter pinCounter;

    void Start () {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
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
        GameObject newPins = Instantiate(pinSet);

        // Disable gravty for each of them (will be enabled by lower method)
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.rigidBody.useGravity = false;
        }

        // Move pins to raised position
        newPins.transform.position += new Vector3(0, 60f, 0);
    }

    public void PerformAction(ActionMaster.Action action) {
        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("End Game Undefined!");
        }
    }
}
