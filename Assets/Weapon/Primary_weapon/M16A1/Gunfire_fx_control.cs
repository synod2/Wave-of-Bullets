using UnityEngine;
using System.Collections;

public class Gunfire_fx_control : MonoBehaviour { //발사 이펙트 컨트롤러
    int timer = 0;

    float rotateDegree;
    GameObject Body;
    // Use this for initialization
    void Start () {

        Body = GameObject.FindGameObjectWithTag("Weapon");

        Vector3 mPosition = Input.mousePosition; //현재 마우스 좌표
        Vector3 pPosition = Body.transform.position;
        mPosition.z = Camera.main.transform.position.z + 2;

        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);//유니티 내에서 표현 가능 좌표로 변환 

        float dy = target.y - pPosition.y;
        float dx = target.x - pPosition.x;


        rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);

    }
	
	// Update is called once per frame
	void Update () {
        
        timer++;
        if (timer == 80)
            Destroy(gameObject);


    }
}
