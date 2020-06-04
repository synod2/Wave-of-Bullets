using UnityEngine;
using System.Collections;

public class Enemy_Control : MonoBehaviour {
    public int health;
    protected Animator animator ;
    AudioSource des_aud;
    public bool die;

    // Use this for initialization
    void Start () {
        health = 200;
        animator = GetComponent<Animator>();
        des_aud = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void hit_damage(int bull_dmg)
    {
        var e_c = GameObject.FindObjectOfType<Game_Root>();

        health -= bull_dmg;
        //Debug.Log("get damage" + health);
        if (health < 0)
        {
            e_c.enemy_down();
            d_enemy();
        }


    }

    public void d_enemy() {
        
        
       
        des_aud.Play();
        die = true;
        animator.SetBool("die", die);
        
    }
    
}
