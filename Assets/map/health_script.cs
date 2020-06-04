using UnityEngine;
using System.Collections;

public class health_script : MonoBehaviour {
    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        Ray2D ray = new Ray2D(this.transform.position, new Vector2(0, -1));
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        var p_s = GameObject.FindObjectOfType<Player_Control>();
        if (Physics2D.Raycast(ray.origin, ray.direction, 0.1f) && hit.collider.tag == "Player")
        {
            audio.Play();
            p_s.health_up();
            Destroy(gameObject);
        }



    }
}
