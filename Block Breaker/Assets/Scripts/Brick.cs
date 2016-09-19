using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public int maxHits;
    public Sprite[] hitSprites;

    private LevelManager levelManager;
    private int timesHit;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D (Collision2D collision) {
        // Incriment hit counter
        timesHit++;

        // Destroy is appropriate or load damage sprite
        if (timesHit >= maxHits) {
            Destroy(gameObject);
        } else {
            LoadSprites();
        }
    }

    void LoadSprites () {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    // TODO Remove once we actually implement
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }
}
