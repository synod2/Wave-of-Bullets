using UnityEngine;
using System.Collections;

public class guiscript : MonoBehaviour {
   
    public GUISkin mySkin;
    AudioSource[] aud;
	// Use this for initialization
	void Start () {
        
        aud = GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnGUI(){
        Vector3 C_pos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2);
        GUI.skin = mySkin;
        if (GUI.Button(new Rect(Screen.width/2, Screen.height*3/ 5, 100, 50), "Start"))
        {
            Application.LoadLevel("start");
            aud[1].Play();
        }

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height*4 / 5, 100, 50), "exit"))
        {
            Application.Quit();
            aud[1].Play();
        }



    }
}
