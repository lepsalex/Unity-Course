using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollTexts, frameTexts;

	public void FillRolls(List<int> rolls) {
        string scoreString = FormatRolls(rolls);
        for (int i = 0; i < scoreString.Length; i++) {
            rollTexts[i].text = scoreString[i].ToString();
        }
    }

    public void FillFrames (List<int> frames) {
        for (int i = 0; i < frames.Count; i++) {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls) {
        string output = "";

        for (int i = 0; i < rolls.Count; i++) {
            int box = output.Length + 1;

            if (rolls[i] == 0) { // always enter zero as "-"
                output += "-";
            } else if ( (box % 2 == 0 || box == 21) && rolls[i - 1] + rolls[i] == 10 ) { // SPARE
                output += "/";
            } else if (box >= 19 && rolls[i] == 10) { // STRIKE in last frame
                output += "X";
            } else if (rolls[i] == 10) { // STRIKE
                output += "X "; // space is important
            } else {
                output += rolls[i].ToString();
            }
        }

        return output;
    }
}
