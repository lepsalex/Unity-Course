using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public float padding = 1f;
    public float projectileSpeed = 10f;
    public float firingRate = 0.2f;
    public float health = 250f;
    public GameObject projectile;

    private float xmin;
    private float xmax;

	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    void Fire () {
        Vector3 startPosition = transform.position + new Vector3(0f, 0.5f, 0f);
        GameObject beam = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, projectileSpeed, 0f);
    }
	
	// Update is called once per frame
	void Update () {

        // Fire laser on space
        if (Input.GetKeyDown(KeyCode.Space)) {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("Fire");
        }

        // Move on left/right arrows
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Restrict player to screen boundries
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
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
