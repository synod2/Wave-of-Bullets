using UnityEngine;
using System.Collections;

public class Hit_fx_control : MonoBehaviour {
    AudioSource hitsound;
    int timer = 0;
    
    void Start () {
        hitsound = GetComponent<AudioSource>();
        hitsound.Play();
    }
	
	// Update is called once per frame
	void Update () {
               
        timer++;
        if (timer == 80)
            Destroy(gameObject);        
    }
}
