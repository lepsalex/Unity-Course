using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    void Awake () {
        // Do not allow multiple instances of MusicPlayer
        if (instance != null) {
            Destroy (gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad (gameObject);
        }
    }
}
