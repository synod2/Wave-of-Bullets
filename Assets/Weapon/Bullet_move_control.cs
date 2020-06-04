using UnityEngine;
using System.Collections;

public class Bullet_move_control : MonoBehaviour
{
    //총알 회전 관리 스크립트
    Vector3 direction;
   
    public float speed = 1000.0f;
    public float d_t = Time.deltaTime;
  

   
    GameObject Body;
    Vector3 s_p;
    // Use this for initialization
    void Start()
    {
        Body = this.gameObject;
        s_p = Body.transform.position;

        Vector3 mPosition = Input.mousePosition; //현재 마우스 좌표
        
        mPosition.z = Camera.main.transform.position.z + 2;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);//유니티 내에서 표현 가능 좌표로 변환

        Vector3 heading = target - Body.transform.position; //목적좌표 - 현재좌표 = 이동방향  
        var distance = heading.magnitude;
        direction = heading / distance; // This is now the normalized direction
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * d_t * 15);

        if (Vector3.Distance(this.transform.position, s_p) > 10)
        {
            Destroy(gameObject);
        }
       
    }
    
}