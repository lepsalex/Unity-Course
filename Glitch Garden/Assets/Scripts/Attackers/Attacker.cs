using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject currentTarget;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    public void SetSpeed (float speed) {
        currentSpeed = speed;
    }

    // Called from animator during attack phase
    public void StrikeCurrentTarget (float damage) {
        Debug.Log(name + " caused damage: " + damage);
    }

    public void Attack (GameObject obj) {
        currentTarget = obj;
    }
}
