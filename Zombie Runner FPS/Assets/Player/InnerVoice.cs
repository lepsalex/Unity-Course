using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour {

    public AudioClip whatHappened;
    public AudioClip goodArea;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = whatHappened;
        audioSource.Play();
    }
	
	void OnFindClearArea() {
        Debug.Log(name + " + OnFindClearArea");
        audioSource.clip = goodArea;
        audioSource.Play();

        Invoke("CallHeli", goodArea.length + 1f);
    }

    void CallHeli() {
        SendMessageUpwards("OnMakeInitialHeliCall");
    }
}
