using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel (string name) {
        // Reset breakable count
        Brick.breakableCount = 0;
        // Load Level
        SceneManager.LoadScene (name);
    }

    public void LoadNextLevel () {
        // Reset breakable count
        Brick.breakableCount = 0;
        // Load Level
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest () {
        Debug.Log("Quit request recieved");
        Application.Quit ();
    }
    
    public void BrickDestroyed() {
        if (Brick.breakableCount <= 0) {
            LoadNextLevel();
        }
    }
}
