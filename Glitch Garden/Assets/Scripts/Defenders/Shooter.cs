using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start () {

        animator = GameObject.FindObjectOfType<Animator>();

        // Create parent object if needed
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }

        // Set lane spawner
        SetMyLaneSpawner();
    }

    void Update () {
        if (IsAttackerAheadInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    void SetMyLaneSpawner () {
        // Find spawner in this lane and set
        Spawner[] spawnerArray = FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawnerArray) {
            if (spawner.transform.position.y == transform.position.y) {
                myLaneSpawner = spawner;
                return;
            }
        }

        // If not found
        Debug.LogError(name + " can't find spawner in lane!");
    }

    bool IsAttackerAheadInLane () {
        // Exit of no attackers
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }

        // Check position of attacker versus our defender (are they ahead)
        foreach (Transform attacker in myLaneSpawner.transform) {
            if (attacker.transform.position.x > transform.position.x) {
                // if the attacker's x pos is greater (more right) than the defender ...
                return true;
            }
        }

        // If none ahead return false (don't shoot)
        return false;
    }

    private void Fire () {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}
