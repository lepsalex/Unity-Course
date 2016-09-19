using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        // Link paddle
        paddle = GameObject.FindObjectOfType<Paddle>();
        // Set ball relative to paddle vector on start
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        // Before player starts round (ie. launches the ball)
        if (!hasStarted) {
            // Update relative vector to keep ball on paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;
        }

        // Listen for mouse click to launch ball
        if (Input.GetMouseButtonDown(0) && hasStarted == false) {
            hasStarted = true;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
        }
	}
}
