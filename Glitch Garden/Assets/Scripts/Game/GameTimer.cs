using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    // Need this to be accessible by lose collider
    public static bool userWon;

    public float levelSeconds = 100f;

    private LevelManager levelManager;
    private Slider slider;
    private AudioSource audioSource;
    private GameObject winOverlay;

	// Use this for initialization
	void Start () {
        // Init static win condition variable to false on every start
        userWon = false;

        // Load needed objects/components
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();

        FindWinOverlay();
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        // Once level time is up (ie. Win Condition)
        if (Time.timeSinceLevelLoad >= levelSeconds && !userWon) {

            userWon = true;

            audioSource.Play();

            if (winOverlay) {
                winOverlay.SetActive(true);
            }

            Invoke("LoadNextLevel", audioSource.clip.length);
        }
	}

    void LoadNextLevel () {
        levelManager.LoadNextLevel();
    }

    void FindWinOverlay () {
        winOverlay = GameObject.Find("Win Overlay");

        if (!winOverlay) {
            Debug.LogWarning("Please create 'Win Overlay' text");
            return;
        }

        winOverlay.SetActive(false);
    }
}
