using UnityEngine;
using System.Collections;

public class Weapon_profile_script : MonoBehaviour {
    public struct Weapon
    {
        public string weapon_type; //1 : Primary , 2:Secondary 3:Thorwable
        public string weapon_name;
        public int ammo;
        public int dmg;  
        public float fire_rate;
        public float reload_rate;
        public float bullet_speed;
    }
    public Weapon Weapon_Profile;
    // Use this for initialization
    void Start () {
        
        Weapon_Profile.weapon_type = "Primary";
        Weapon_Profile.weapon_name = "M16A1";
        Weapon_Profile.ammo = 30;
        Weapon_Profile.dmg = 20;
        
        Weapon_Profile.fire_rate = 0.2f;
        Weapon_Profile.reload_rate = 2f;
        Weapon_Profile.bullet_speed = 75f;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
