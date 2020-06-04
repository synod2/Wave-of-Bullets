using UnityEngine;
using System.Collections;

public class Game_start : MonoBehaviour {
    protected Animator animator;
    AudioSource[] sound;
    int timer;
    int s_enum;
   
	// Use this for initialization
	void Start () {
        GameObject[] numofe = GameObject.FindGameObjectsWithTag("enemy");
        s_enum = numofe.Length;
        sound = GetComponents<AudioSource>();
        animator = GetComponent<Animator>();
        timer = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer == 1)
        {
            sound[4].Play();
            sound[0].Play();
            Invoke("set_end", 1.5f);

        }
        var b_s = GameObject.FindObjectOfType<Player_Control>();
        GameObject[] numofe = GameObject.FindGameObjectsWithTag("enemy");
        int e_num = numofe.Length - s_enum / 2;
        
        
        //Debug.Log(b_s.is_alive + "is alive?");

    }

    void return_main() {
        
        Application.LoadLevel("main_scene");
    }

    public void win()
    {
        animator.SetBool("is_end", false);
        animator.SetBool("win", true);
        Invoke("set_end", 1.5f);
        Invoke("return_main", 3f);
    }

    void restart()
    {
        Application.LoadLevel("start");
        Invoke("set_end", 1.5f);
    }

    void set_end() {
        animator.SetBool("is_end", true);       

    }

    public void pre_game_end()
    {
        sound[2].Play();
        Invoke("game_end", 1f);

    }

    void game_end() {
        sound[5].Play();
        sound[1].Play();
        animator.SetBool("is_end", false);
        animator.SetBool("is_dead", true);
        Invoke("set_end", 1.5f);
        Invoke("restart", 2.5f);
    }

   
}
