using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private List<int> rolls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall) {
        try {
            rolls.Add(pinFall);
            ball.Reset();
            pinSetter.PerformAction(ActionMaster.NextAction(rolls));
        } catch {
            Debug.LogWarning("Bowl() failed");
        }

        UpdateDisplay();
    }

    public void UpdateDisplay() {
        print(rolls.ToArray()[1]);
        // Fill roll card
        try {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        }
        catch {
            Debug.LogWarning("UpdateDisplay() failed");
        }
    }

}
