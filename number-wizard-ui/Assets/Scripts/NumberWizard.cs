using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class NumberWizard : MonoBehaviour {

    // Instance variables
    int max;
    int min;
    int guess;

    // Win condition
    public int maxGuessesAllowed = 5;

    // UI
    public Text guessText;

    // Use this for initialization
    void Start() {
        StartGame();
    }
    
    // Game start
    void StartGame() {
        // Init game min/max variables
        max = 1000;
        min = 1;
        
        // Init guess to a random num between min and max +1
        // max + 1 because we want to include max in range
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
        
        // Fixes rounding problem
        max = max + 1;
    }
    
    // Calculate next guess
    void NextGuess() {
        // Check for win
        maxGuessesAllowed = maxGuessesAllowed - 1;
        if (maxGuessesAllowed <= 0) {
            SceneManager.LoadScene("Win");
        }
        // Update guess
        guess = (max + min) / 2;
        guessText.text = guess.ToString();
    }

    public void GuessHigher() {
        min = guess;
        NextGuess();
    }

    public void GuessLower() {
        max = guess;
        NextGuess();
    }
}
