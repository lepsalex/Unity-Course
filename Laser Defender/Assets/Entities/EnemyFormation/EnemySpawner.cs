using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    // Use this for initialization
    void Start () {
        // For each nested object within this object (ie. all the positions)
        foreach (Transform child in transform) {
            // Create a game object at the postion of the position object
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            // Nest the new object under the positon object
            enemy.transform.parent = child;
        }
    }

    // Update is called once per frame
    void Update () {

    }
}
