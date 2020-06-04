using UnityEngine;
using System.Collections;

public class Enemy_weapon_control : MonoBehaviour {

    AudioSource firesound;
    AudioSource reloadsound;
    public GameObject BulletPrefeb;
    public float reload_rate ;
    public float fireRate = 0.2f; //총알 지연 시간 설정
    public int ammo ;
    public int ammo_c;
    float reload_timer;
    public bool is_reload = false;
    private float nextFire = 0.0f; //다음 총알 발사시간 
                                   // Use this for initialization
    Vector3 direction;
    GameObject player;

    void Start () {
        AudioSource[] sounds;
        sounds = GetComponents<AudioSource>();
        firesound = sounds[0];
        reloadsound = sounds[1];
        reload_rate = 2.0f;
        ammo = 25;
        ammo_c = ammo;
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 pPosition = player.transform.position;
        
        //Vector3 target = Camera.main.ScreenToWorldPoint(pPosition);//유니티 내에서 표현 가능 좌표로 변환

        Vector3 heading = pPosition - this.transform.position;
        var distance = heading.magnitude;
        direction = heading / distance; // This is now the normalized direction


        // var f_s = GameObject.FindObjectOfType<Create_Gunfire_fx>(); //발사 이펙트 스크립트
        Ray2D ray = new Ray2D(this.transform.position, new Vector2(direction.x, direction.y));
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        int LayerMask = 1 << 9;
        if (Physics2D.Raycast(ray.origin, ray.direction, 3f,LayerMask) && hit.collider.tag == "Player" && Time.time > nextFire && is_reload == false)
        {   if (ammo_c > 0)
            {
                nextFire = Time.time + fireRate;
                Instantiate(BulletPrefeb, this.transform.position, Quaternion.identity);
               // f_s.fire_on();
                ammo_c--;
                firesound.Play();
            
            }
            else
            {
                is_reload = true;
                reloadsound.Play();                
                Invoke("Reload", reload_rate);
            }
        }        

    }
    void Reload()
    {
        Debug.Log(is_reload + " is reload");
        ammo_c = ammo;
        is_reload = false;
    }
}
