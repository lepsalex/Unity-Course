using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour {

    // Instance variables
    int max;
    int min;
    int guess;

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
		
        // Print instructions to screen
        print("========================");
        print("Welcome to Number Wizard");
        print("Pick a number in your head, but don't tell me ...");
		
        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);
		
        print("Is the number higher or lower than " + guess + "?");
        print("Up = higher, down = lower, return = equal");
        
		// Fixes rounding problem
		max = max + 1;
    }
    
    // Calculate next guess
    void NextGuess() {
		guess = (max + min) / 2;
		print("Higher or lower than " + guess + "?");
		print("Up = higher, down = lower, return = equal");
    }
	
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
			NextGuess();
        } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            max = guess;
			NextGuess();
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            print("I won!");
            StartGame();
        }
    }
}
