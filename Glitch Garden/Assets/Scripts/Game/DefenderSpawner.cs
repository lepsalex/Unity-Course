using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject defenderParent;
    private StarDisplay starDisplay;

    void Start () {
        defenderParent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (!defenderParent) {
            defenderParent = new GameObject("Defenders");
        }
    }

    void OnMouseDown () {
        // If game is over just return and don't do anything
        if (GameTimer.userWon) { return; }

        // Get/set position variables
        Vector2 spawnPosition = SnapToGrid(CalculateWorldPointofMouseClick());

        // Assign defender
        GameObject defender = Button.selectedDefender;

        // Get star cost of defender from defender game object
        int defenderCost = defender.GetComponent<Defender>().starCost;

        // If we have stars available, spawn the defender
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
            SpawnDefender(spawnPosition, defender);
        } else {
            Debug.Log("Insufficient stars to spawn!");
        }
    }

    private void SpawnDefender (Vector2 spawnPosition, GameObject defender) {
        Quaternion zeroRot = Quaternion.identity;

        // Init defender game object
        GameObject newDefender = Instantiate(defender, spawnPosition, zeroRot) as GameObject;
        newDefender.transform.parent = defenderParent.transform;
    }

    Vector2 SnapToGrid (Vector2 rawWorldPosition) {
        float newXValue = Mathf.RoundToInt(rawWorldPosition.x);
        float newYValue = Mathf.RoundToInt(rawWorldPosition.y);
        return new Vector2(newXValue, newYValue);
    }

    Vector2 CalculateWorldPointofMouseClick () {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f; //doesn't matter

        Vector3 clickScreenPosition = new Vector3(mouseX, mouseY, distanceFromCamera);

        Vector2 clickWorldPosition = myCamera.ScreenToWorldPoint(clickScreenPosition);

        return clickWorldPosition;
    }
}
