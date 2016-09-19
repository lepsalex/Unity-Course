using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel (string name) {
        // Debug.Log("Level load requested for: " + name);
        // Application.LoadLevel(name);
        SceneManager.LoadScene (name);
    }

    public void LoadNextLevel () {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest () {
        // Debug.Log("Quit request recieved");
        Application.Quit ();
    }

}
