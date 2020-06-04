using UnityEngine;
using System.Collections;

public class Boost_fx_create : MonoBehaviour { //부스터 이펙트 생성 컨트롤러
    public GameObject Boostfx;
    AudioSource[] sounds;
    // Use this for initialization
    void Start () {
        sounds = GetComponents<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {     
            
            
        
	}

    public void Boost_on() {
        sounds[1].Play();
        Instantiate(Boostfx, this.transform.position, Quaternion.identity);
       // sounds[0].Play();
        
        sounds[2].Play();
    }
}
