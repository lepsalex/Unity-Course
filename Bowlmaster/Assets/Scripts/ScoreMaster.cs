using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

    // Returns a list of cumulative score, like a frame card
    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls)) {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    // Returns a list of individual frame score, not like a frame card
    public static List<int> ScoreFrames(List<int> rolls) {
        List<int> frames = new List<int>();

        for (int i = 1; i < rolls.Count; i += 2) {

            // Prevent 11th frame
            if (frames.Count == 10) { break; }
            
            // Normal "OPEN" frame
            if (rolls[i - 1] + rolls[i] < 10) {
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            // Prevent insufficient look-ahead
            if (rolls.Count - i <= 1) { break; }

            // STRIKE
            if (rolls[i - 1] == 10) {
                i--; // strike frame has only one bowl
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            } else if (rolls[i - 1] + rolls[i] == 10) {
                // SPARE bonus
                frames.Add(10 + rolls[i + 1]);
            }
        }

        return frames;
    }
}
