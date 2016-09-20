using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel (string name) {
        // Load Level
        SceneManager.LoadScene (name);
    }

    public void LoadNextLevel () {
        // Load Level
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest () {
        Debug.Log("Quit request recieved");
        Application.Quit ();
    }
}
