using UnityEngine;
using System.Collections;

public class E_Bullet_Sprite_control : MonoBehaviour
{
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
    void Start()
    {
        AudioSource block_s;
        block_s = GetComponent<AudioSource>();
        colidbox = GetComponent<BoxCollider2D>();
        Body = this.gameObject;
        damage = 20;

        Vector3 pPosition = GameObject.FindGameObjectWithTag("Player").transform.position; //현재 플레이어 위치
        Vector3 oPosition = Body.transform.position;          
            
        float dy = pPosition.y - oPosition.y;
        float dx = pPosition.x - oPosition.x;

        //Debug.Log ("dy"+dy+"dx"+dx);
        //Debug.Log ("direction"+direction);

        rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);

        //Debug.Log ("rotate" + rotateDegree);
        blocks = block_s;

    }

    // Update is called once per frame
    void Update()
    {
        var box = colidbox.transform.position;
        //transform.Translate(direction * speed * d_t * 15);

        //충돌관리 
        Ray2D ray = new Ray2D(box, new Vector2(1, 0));
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (Physics2D.Raycast(ray.origin, ray.direction, 0.1f) && hit.collider.tag == "map")
        {
            blocks.Play();
            Destroy(gameObject);

        }


        if (Physics2D.Raycast(ray.origin, ray.direction, 0.1f) && hit.collider.tag == "Player")
        {
            Player_Control p_c = hit.collider.gameObject.GetComponent<Player_Control>();
            fe1_stand_head p_h = hit.collider.gameObject.GetComponent<fe1_stand_head>();
            if (p_c != null)
                p_c.hit_damage(damage);
            if (p_h != null)
                p_h.hit_damage(damage);

            Instantiate(Hit_fx, this.transform.position, Quaternion.identity);
            Destroy(gameObject);            // Debug.Log("hit");

        }
        

    }
}
