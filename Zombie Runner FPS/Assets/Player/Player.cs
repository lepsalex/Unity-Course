using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform playerSpawnPoints; // parent of spawn points
    public GameObject landingAreaPrefab;
    public bool reSpawn = false;

    private Transform[] spawnPoints;
    private bool lastToggle = false;

	// Use this for initialization
	void Start () {
        spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (lastToggle != reSpawn) {
            Respawn();
            reSpawn = false;
        } else {
            lastToggle = reSpawn;
        }
    }

    void Respawn() {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position;
    }

    void OnFindClearArea() {
        Invoke("DropFlare", 3f);
    }

    void DropFlare() {
        Instantiate(landingAreaPrefab, transform.position, transform.rotation);
    }
}
