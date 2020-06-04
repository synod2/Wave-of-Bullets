using UnityEngine;
using System.Collections;

public class Weapon_fire : MonoBehaviour
{
    AudioSource firesound;
    AudioSource reloadsound;
    public GameObject BulletPrefeb;
    GameObject Body;
    public float reload_rate;
    public float fireRate; //총알 지연 시간 설정
    public int ammo;
    public int ammo_c;
    float reload_timer;
    public bool is_reload = false;
    private float nextFire = 0.0f; //다음 총알 발사시간 

    // Use this for initialization
    
    void Start()
    {
        AudioSource[] sounds;      
          
        sounds = GetComponents<AudioSource>();
        firesound = sounds[0];
        reloadsound = sounds[1];
        var wp = GameObject.FindObjectOfType<Weapon_profile_script>();
        fireRate = wp.Weapon_Profile.fire_rate * 0.5f;
        ammo = wp.Weapon_Profile.ammo;
        reload_rate = wp.Weapon_Profile.reload_rate;
        Body = GameObject.FindGameObjectWithTag("Weapon");
        ammo_c = ammo;
    }

    // Update is called once per frame
    void Update()
    {

        var f_s = GameObject.FindObjectOfType<Create_Gunfire_fx>(); //발사 이펙트 스크립트

        if (Input.GetMouseButton(0) && Time.time > nextFire && is_reload != true)
        {
            if (ammo_c > 0)
            {
                nextFire = Time.time + fireRate;
                Instantiate(BulletPrefeb, Body.transform.position, Quaternion.identity);
                f_s.fire_on();
                ammo_c--;
                //Debug.Log(ammo_c + " ammo");
                firesound.Play();
            }
            else
            {
                pre_Reload();
            }
        }

        if (Input.GetKey(KeyCode.R) && ammo_c<ammo)
        {
            pre_Reload();
        }
    }

    void pre_Reload()
    {
        is_reload = true;
        reloadsound.Play();
        Invoke("Reload", reload_rate);
    }
    void Reload()
    {
        //Debug.Log(is_reload + " is reload");
        ammo_c = ammo;
        is_reload = false;

    }

  
}