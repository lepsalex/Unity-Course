using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    public int starCost = 10;

    private StarDisplay starDisplay;

    void Start () {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }
	
    public void AddStars (int amount) {
        starDisplay.AddStars(amount);
    }
}
