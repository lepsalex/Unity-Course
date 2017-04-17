using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // add bowl result to list of all bowls
        rolls.Add(pinFall);

        // Reset
        ball.Reset();

        // Perform the appropriate action ...
        pinSetter.PerformAction(ActionMaster.NextAction(rolls));

        // Fill roll card
        try {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        } catch {
            Debug.LogWarning("Fill roll card functions failed");
        }
    }

}
