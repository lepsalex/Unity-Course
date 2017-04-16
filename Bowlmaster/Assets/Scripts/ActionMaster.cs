using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

    public enum Action {Tidy, Reset, EndTurn, EndGame};

    private int[] bowls = new int[21];
    private int bowl = 1;

	public Action Bowl(int pins) {

        if (pins < 0 || pins > 10) { throw new UnityException("Invalid pins;"); }

        // Insert bowl results
        bowls[bowl - 1] = pins;

        // End Game
        if (bowl == 21) {
            return Action.EndGame;
        }

        // Last frame strike
        if (bowl == 19 && pins == 10) {
            bowl += 1;
            return Action.Reset;
        }

        // Last frame logic
        if (bowl == 20) {
            bowl += 1;

            if (bowls[19 - 1] == 10 && bowls[20 - 1] != 10) {
                return Action.Tidy;
            }

            if ((bowls[19 - 1] + bowls[20 - 1]) % 10 == 0) {
                return Action.Reset;
            }

            if (Bowl21Awarded()) {
                return Action.Tidy;
            }

            return Action.EndGame;
        }

        // First bowl of frames 1 - 9
        if (bowl % 2 != 0) {

            if (pins == 10) {
                bowl += 2;
                return Action.EndTurn;
            }

            bowl += 1;
            return Action.Tidy;
        }

        // Second bowl of frame 1 - 9
        if (bowl % 2 == 0) {
            bowl += 1;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded() {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }
}
