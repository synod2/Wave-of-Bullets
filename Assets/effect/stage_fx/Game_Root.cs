using UnityEngine;
using System.Collections;

public class Game_Root : MonoBehaviour {
    GameObject Body;
    public int enemy_count;
    // Use this for initialization
    void Start () {
        enemy_count = 16;
    }
	
	// Update is called once per frame
	void Update () {
        Body = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = new Vector3(Body.transform.position.x, Body.transform.position.y, Body.transform.position.z);

    }

    public void enemy_down() {
        Debug.Log("enemydown");
        enemy_count-=1;
    }
}
