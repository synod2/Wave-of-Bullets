using UnityEngine;
using System.Collections;

public class tuto_script : MonoBehaviour {
    AudioSource aud;
    // Use this for initialization
    void Start () {
        aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        if (GUI.Button(new Rect(320, 360, 100, 50), "exit"))
        {
            Destroy(gameObject);
            aud.Play();
        }

    }
}
