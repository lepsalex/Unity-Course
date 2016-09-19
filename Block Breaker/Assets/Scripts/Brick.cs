using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;

    private LevelManager levelManager;
    private int timesHit;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");

        // If brick is breakable increment
        if (isBreakable) {
            breakableCount++;
        }

        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter2D (Collision2D collision) {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.6f);
        if (isBreakable) {
            HandleHits();
        }
    }

    void HandleHits () {
        // Incriment hit counter
        timesHit++;

        // Get max hits
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits) {
            // Decrement count of remaining breakable bricks
            breakableCount--;
            // Message level manager that a brick has been destroyed
            levelManager.BrickDestroyed();
            // Destroy if appropriate
            Destroy(gameObject);
        } else {
            // ... or load damage sprite
            LoadSprites();
        }
    }

    void LoadSprites () {
        int spriteIndex = timesHit - 1;

        // Handle if sprite is missing on lookup
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    // TODO Remove once we actually implement
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }
}
