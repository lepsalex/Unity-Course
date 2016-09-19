using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;

    // Use this for initialization
    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update () {
        if (!autoPlay) {
            // Player Control
            MoveWithMouse();
        } else {
            AutoPlay();
        }
    }

    void MoveWithMouse () {
        // New vector 3 with starting values
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        // Set position in variable (in world units)
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        // Update x with mouse position
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

        // Update position
        this.transform.position = paddlePos;
    }

    void AutoPlay () {
        // New vector 3 with starting values
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        // Get ball position
        float ballPos = ball.transform.position.x;

        // Update x with mouse position
        paddlePos.x = Mathf.Clamp(ballPos, 0.5f, 15.5f);

        // Update position
        this.transform.position = paddlePos;
    }
}
