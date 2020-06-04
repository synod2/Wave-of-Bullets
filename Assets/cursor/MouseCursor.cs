using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour {

    protected Animator animator;
    public bool is_reload=false;

    // Use this for initialization
    void Start () {
        
        animator = GetComponent<Animator>();
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        var r_s = GameObject.FindObjectOfType<Weapon_fire>(); //재장전 정보 받아올 스크립트

        Vector3 mPosition = Input.mousePosition; //현재 마우스 좌표
        
        mPosition.z = Camera.main.transform.position.z + 12;
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);//유니티 내에서 표현 가능 좌표로 변환
        this.transform.position = target;
        is_reload = r_s.is_reload;
        animator.SetBool("reload", is_reload);

    }
}
