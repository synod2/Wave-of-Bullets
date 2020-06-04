using UnityEngine;
using System.Collections;

public class Enemy_head_control : MonoBehaviour
{
    
    Enemy_Control e_c;
    GameObject player;
    GameObject e_b;

    public float speed = 1000.0f;
    
    // Use this for initialization
    void Start()
    {
        e_b = gameObject.transform.parent.gameObject;
        e_c = e_b.GetComponent<Enemy_Control>();
        
        
    }

    // Update is called once per frame
    void Update()
    { float d_t = Time.deltaTime;
    player = GameObject.FindGameObjectWithTag("Player");
        Vector3 pPosition = player.transform.position; //현재 플레이어 좌표 
        Vector3 oPosition = this.transform.position; //현재 오브젝트 좌표
        // pPosition.z = Camera.main.transform.position.z + 2;
        // Vector3 target = Camera.main.ScreenToWorldPoint(pPosition);//유니티 내에서 표현 가능 좌표로 변환
        Vector3 target = pPosition;
        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree;

        if (target.x > oPosition.x) //마우스 커서가 캐릭터의 오른쪽, 혹은 왼쪽에 있는지 확인하여 스프라이트 반전 및 회전
            rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg * -1;
        else
            rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg + 180;

        //float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg +180;

        //구해진 각도를 오일러 회전 함수에 적용하여 z축을 기준으로 게임 오브젝트를 회전시킵니다.
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
        if (e_c.die == true)
            { Destroy(gameObject); }

    }

    public void hit_damage(int bull_dmg)
    {
        //Debug.Log("HeadSHOT" + e_c.health);
        e_c.health -= bull_dmg * 2;
        if (e_c.health < 0)
        {
            e_c.d_enemy();
        }

    }
}