using UnityEngine;
using System.Collections;

public class Bullet_Sprite_control : MonoBehaviour {
    //발사된 총알 관리 스크립트
    AudioSource blocks;
    float rotateDegree;
   BoxCollider2D colidbox;
    public float speed = 1000.0f;
    public float d_t = Time.deltaTime;
	SpriteRenderer sprite;
    public GameObject Hit_fx;
    int damage;
    
    GameObject Body;
    // Use this for initialization
    void Start() {
        AudioSource block_s;
        block_s = GetComponent<AudioSource>();
        colidbox = GetComponent<BoxCollider2D>();
		Body = GameObject.FindGameObjectWithTag("Weapon");
        var wp = GameObject.FindObjectOfType<Weapon_profile_script>();
        damage = wp.Weapon_Profile.dmg;
        Vector3 mPosition = Input.mousePosition; //현재 마우스 좌표
        Vector3 pPosition = Body.transform.position;
        mPosition.z = Camera.main.transform.position.z + 2;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);//유니티 내에서 표현 가능 좌표로 변환

        float dy = target.y - pPosition.y;
        float dx = target.x - pPosition.x;

		//Debug.Log ("dy"+dy+"dx"+dx);
		//Debug.Log ("direction"+direction);

        rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);

        //Debug.Log ("rotate" + rotateDegree);
        blocks = block_s;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        var box= colidbox.transform.position;
        //transform.Translate(direction * speed * d_t * 15);

        if (Vector3.Distance(this.transform.position,Body.transform.position) > 10)
        {
            Destroy(gameObject);
        }
        //충돌관리 
        Ray2D ray = new Ray2D(box, new Vector2(1, 0));
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (Physics2D.Raycast(ray.origin, ray.direction,0.1f) && hit.collider.tag=="map")
        {
            blocks.Play();
            Destroy(gameObject);
            
        }

       
        if (Physics2D.Raycast(ray.origin, ray.direction,0.1f) && hit.collider.tag == "enemy")
        {
            Enemy_Control e_c = hit.collider.gameObject.GetComponent<Enemy_Control>();
            Enemy_head_control h_c = hit.collider.gameObject.GetComponent<Enemy_head_control>();
            if (e_c != null)
                e_c.hit_damage(damage);
            if (h_c != null)
                h_c.hit_damage(damage);

            Instantiate(Hit_fx, this.transform.position, Quaternion.identity);
           // Debug.Log("hit");
            Destroy(gameObject);
        }

        if (Physics2D.Raycast(ray.origin, ray.direction, 0.1f) && hit.collider.tag == "player")
        {
            Enemy_Control e_c = hit.collider.gameObject.GetComponent<Enemy_Control>();
            Enemy_head_control h_c = hit.collider.gameObject.GetComponent<Enemy_head_control>();
            if (e_c != null)
                e_c.hit_damage(damage);
            if (h_c != null)
                h_c.hit_damage(damage);

            Instantiate(Hit_fx, this.transform.position, Quaternion.identity);
            Debug.Log("hit");
            Destroy(gameObject);
        }

    }
}
