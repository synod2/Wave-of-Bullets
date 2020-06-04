using UnityEngine;
using System.Collections;


public class Player_Control : MonoBehaviour
{
    protected Animator animator;
    public Rigidbody2D rb;
    private float directionX = 0;
    private float directionY = 0;
    private bool running = false;
    public bool jumping = false;
    public bool is_ground = true;
    public int jumptimer=100;
    public AudioSource[] walk_sound;

    int walk_timer;
    public int health;
    private float speed;
    public bool is_alive=true;   
       
    // Use this for initialization
    void Start()
    {
        health = 200;
        walk_sound = GetComponents<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        walk_timer = 0;
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Ray2D ray = new Ray2D(this.transform.position, new Vector2(0, -1));

        int layerMask = 1 << 8;
        if (Physics2D.Raycast(ray.origin, ray.direction, 1f,layerMask))//땅에 붙어있는지 체크    
        {
            is_ground = true;
        }
        else
        {
            is_ground = false;
        }
        
        if (walk_timer > 100)
        {
            walk_timer = 0;
        }
        var b_s = GameObject.FindObjectOfType<Boost_fx_create>(); //부스터 이펙트 스크립트
        if (Input.GetKey(KeyCode.A))
        {
            running = true;
            directionX = -1;
            directionY = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            running = true;
            directionX = 1;
            directionY = 0;
        }
        else
        {
            running = false;
            directionX = 0;
            directionY = 0;
        }
        if (running)
        {
            walk_timer++;
            transform.Translate(new Vector3(directionX, directionY, 0) * speed  * 3 * dt);
            if (is_ground==true && walk_timer%15==0)
            {
                    
                walk_sound[walk_timer%4].Play();
            }
          
        }
        //Debug.Log(running + " is run");
        if (Input.GetKey(KeyCode.W) && jumptimer>0)
        {
            jumping = true;
            running = false;
            if (jumptimer == 0)
                Invoke("recharge_boost", 1);
            else
                jumptimer--;
            if(jumptimer%7==0)
             b_s.Boost_on(); //부스터 이펙트 출력
        }
        else if(jumptimer < 200 && !Input.GetKey(KeyCode.W))
        {
            jumptimer++;
        }
       // Debug.Log(jumptimer+" jump");
        if (jumping)
        {
            rb.AddForce(new Vector2(0, 9));            
        }

 

        //애니메이션 관리파트
        animator.SetFloat("directionX", directionX); 
        animator.SetFloat("directionY", directionY);
        animator.SetBool("Running", running);
        animator.SetBool("Jump", jumping);
        jumping = false;
       
    }
    public void health_up() {
        health += 50;
        if (health > 200)
            health = 200;
    }

    void recharge_boost() { }

    public void hit_damage(int bull_dmg)
    {

        health -= bull_dmg;
        //Debug.Log("get damage" + health);
        if (health < 0)
            dead();


    }

    public void dead() {       
        is_alive = false;
        var b_s = GameObject.FindObjectOfType<Game_start>();
        
        b_s.pre_game_end();
        Destroy(gameObject);        
    }
}