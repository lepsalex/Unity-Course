using UnityEngine;
using System.Collections;

public class EnemyFormationController : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 5f;
    public float spawnDelay = 0.5f;

    private float xmin;
    private float xmax;
    private bool movingRight = true;

    // Show gizmos for this
    void OnDrawGizmos () {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    // Use this for initialization
    void Start () {

        // Set bounds for formation movement
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
        xmin = leftmost.x;
        xmax = rightmost.x;

        // Initial enemy spawn
        SpawnUntilFull();
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

        // Respawn on all dead
        if (AllMembersDead()) {
            SpawnUntilFull();
        }
    }

    void SpawnUntilFull () {
        // Get next free position
        Transform freePosition = NextFreePosition();

        // If free position exists
        if (freePosition) {
            // Create a game object at the postion of the position object
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;

            // Nest the new object under the positon object
            enemy.transform.parent = freePosition;
        }

        // If there is a next position available
        if (NextFreePosition()) {
            // Call function every spawnDelay seconds (recursion!)
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }

    Transform NextFreePosition () {
        foreach (Transform childPositionPageObject in transform) {
            if (childPositionPageObject.childCount == 0) {
                return childPositionPageObject;
            }
        }
        return null;
    }

    bool AllMembersDead () {
        foreach (Transform childPositionPageObject in transform) {
            if (childPositionPageObject.childCount > 0) {
                return false;
            }
        }
        return true;
    }
}
