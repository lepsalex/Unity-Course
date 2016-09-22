using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject projectile;
    public float health = 150f;
    public float projectileSpeed = 10f;
    public float shotsPerSecond = 0.5f;

    void Update () {
        // Update probability every update
        float probability = shotsPerSecond * Time.deltaTime;
        if (probability > Random.value) {
            Fire();
        }
    }

    void Fire () {
        Vector3 startPosition = transform.position + new Vector3(0f, -0.5f, 0f);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -projectileSpeed, 0f);
    }

	void OnTriggerEnter2D (Collider2D collider) {
        // Get the projectile script component and save to missile variable
        Projectile missile = collider.gameObject.GetComponent<Projectile>();

        if (missile) {
            // Reduce health by missile damage
            health -= missile.GetDamage();
            // Call missiles Hit method (destroy)
            missile.Hit();

            // Destroy enemy if hit points are depleted
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }

}
