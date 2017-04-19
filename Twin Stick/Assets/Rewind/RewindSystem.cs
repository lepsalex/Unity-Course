using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSystem : MonoBehaviour {

    private GameManager gameManager;
    private Stack<MyKeyFrame> keyFrames = new Stack<MyKeyFrame>(200);
    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.recording) {
            Record();
        } else {
            PlayBack();
        }
    }

    private void PlayBack() {
        // If we haven't used up our stack and we are not in paused mode
        if (keyFrames.Count >= 0 && !gameManager.paused) {
            rigidBody.isKinematic = true;

            // Pop the latest frame and move to that position (the rewind)
            MyKeyFrame frame = keyFrames.Pop();
            transform.position = frame.pos;
            transform.rotation = frame.rot;
        }
    }

    private void Record () {
        // Do not record in paused mode ...
        if (!gameManager.paused) {
            rigidBody.isKinematic = false;

            // Stack the next frame 
            keyFrames.Push(new MyKeyFrame(Time.time, transform.position, transform.rotation));
        }
    }
}

/// <summary>
/// A structure for storing time, rotation, and position.
/// </summary>
public struct MyKeyFrame {
    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame (float aTime, Vector3 aPos, Quaternion aRot) {
        time = aTime;
        pos = aPos;
        rot = aRot;
    }
}
