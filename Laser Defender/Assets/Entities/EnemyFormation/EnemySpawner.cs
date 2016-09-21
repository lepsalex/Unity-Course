using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;

    private float xmin;
    private float xmax;
    private bool movingRight = true;

    // Use this for initialization
    void Start () {

        // Set bounds for formation movement
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
        xmin = leftmost.x;
        xmax = rightmost.x;

        // For each nested object within this object (ie. all the positions) spanw an enemy
        foreach (Transform child in transform) {
            // Create a game object at the postion of the position object
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            // Nest the new object under the positon object
            enemy.transform.parent = child;
        }
    }

    void OnDrawGizmos () {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Update is called once per frame
    void Update () {
        // Move enemies from side to side
        if (movingRight) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        } else {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);

        // Flip direction of travel
        if (leftEdgeOfFormation <= xmin) {
            movingRight = true;
        }  else if (rightEdgeOfFormation >= xmax) {
            movingRight = false;
        }
    }
}
