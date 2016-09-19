using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    // Update is called once per frame
    void Update () {
        // New vector 3 with starting values
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        // Set position in variable (in world units)
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        // Update x with mouse position
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

        this.transform.position = paddlePos;
	}
}
