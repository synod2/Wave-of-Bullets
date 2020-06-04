using UnityEngine;
using System.Collections;

public class Camera_control : MonoBehaviour {
    GameObject Body;
    int s_enum;
    // Use this for initialization
    void Start () {
        Body = GameObject.FindGameObjectWithTag("Player");
        GameObject[] numofe = GameObject.FindGameObjectsWithTag("enemy");
        s_enum = numofe.Length;
    }
	
	// Update is called once per frame
	void LateUpdate () {
      
        Vector3 mPosition = Input.mousePosition; //현재 마우스 좌표
        mPosition.z = Camera.main.transform.position.z + 2;
        this.transform.position = new Vector3(Body.transform.position.x, Body.transform.position.y, Body.transform.position.z - 1);

    }
    void OnGUI()
    {
        GameObject[] numofe = GameObject.FindGameObjectsWithTag("enemy");
        int e_num = numofe.Length - s_enum/2;
        

        GUI.Box(new Rect(5, 5, 300, 45),"");
        var wf = GameObject.FindObjectOfType<Weapon_fire>();
        var bs = GameObject.FindObjectOfType<Player_Control>();
        var e_c = GameObject.FindObjectOfType<Game_start>();
        GUI.Label(new Rect(10, 10, 100, 90), "Ammo : "+wf.ammo_c+"/"+wf.ammo);
        if(wf.is_reload)
            GUI.Label(new Rect(10, 20, 100, 90), "Reloading");
        GUI.Label(new Rect(120, 10, 140, 90), "Booster : " + bs.jumptimer + "/ 200");
        GUI.Label(new Rect(120, 20, 140, 90), "health : " + bs.health + "/ 200");
        GUI.Label(new Rect(120, 30, 140, 90), "left enemy : " + e_num);

        if (e_num == 0)
        {
            e_c.win();
        }

    }
}
