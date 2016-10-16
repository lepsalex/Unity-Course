using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;
    public GameObject defenderPrefab;

    private Button[] buttonArray;
    private Text costText;

    // Use this for initialization
    void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();

        // Update star cost text
        costText = GetComponentInChildren<Text>();
        if (!costText) { Debug.LogWarning(name + " is missing cost text"); }
        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}

    void OnMouseDown () {
        // If game is over just return and don't do anything
        if (GameTimer.userWon) { return; }

        foreach (Button thisButton in buttonArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
