using UnityEngine;
using System.Collections;

public class start_gui : MonoBehaviour {
    public GUISkin mySkin;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        Vector3 C_pos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2);
        GUI.skin = mySkin;
        

        if (GUI.Button(new Rect(320, 10, 100, 50), "Misson Start"))
        {
            Application.LoadLevel("stage1");
            
        }

        if (GUI.Button(new Rect(420, 10, 100, 50), "reset"))
        {
            Application.LoadLevel("start");
            
        }

        if (GUI.Button(new Rect(520, 10, 100, 50), "exit"))
        {
            Application.LoadLevel("main_scene");
           
        }
        GUI.Label(new Rect(320, 60, 300, 50), "w , a, d to move , left click to shoot");
    }
}
