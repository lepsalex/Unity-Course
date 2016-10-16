using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public GameObject[] attackerPrefabArray;
    public GameObject[] spawners;

    private bool isSpawning;
    private GameObject currentSpawner;

    void Update () {
        if (!isSpawning) {
            isSpawning = true;
            int attackerIndex = Random.Range(0, attackerPrefabArray.Length);
            int spawnerIndex = Random.Range(0, spawners.Length);
            StartCoroutine(SpawnObject(attackerIndex, spawnerIndex));
        }
    }

    IEnumerator SpawnObject (int attackerIndex, int spawnerIndex) {
        GameObject attackerGameObject = attackerPrefabArray[attackerIndex];
        currentSpawner = spawners[spawnerIndex];
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float spawnDelay = attacker.seenEverySeconds;
        float randomDelay = Random.Range(spawnDelay - 3, spawnDelay + 3);
        yield return new WaitForSeconds(randomDelay);

        GameObject spawnedObject = Instantiate(attackerGameObject) as GameObject;
        spawnedObject.transform.parent = currentSpawner.transform;
        spawnedObject.transform.position = currentSpawner.transform.position;
        isSpawning = false;
    }
}
