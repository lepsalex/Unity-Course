using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;

    private GameObject defenderParent;

    void Start () {
        defenderParent = GameObject.Find("Defenders");

        if (!defenderParent) {
            defenderParent = new GameObject("Defenders");
        }
    }

    void OnMouseDown () {
        // Get/set position variables
        Vector2 spawnPosition = SnapToGrid( CalculateWorldPointofMouseClick() );
        Quaternion zeroRot = Quaternion.identity;

        // Init defender game object
        GameObject newDefender = Instantiate(Button.selectedDefender, spawnPosition, zeroRot) as GameObject;
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
