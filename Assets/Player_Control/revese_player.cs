using UnityEngine;
using System.Collections;

public class revese_player : MonoBehaviour {
	protected Animator animator;
	bool running ;
	bool reverse = false;
	//캐릭터 스프라이트 좌우 반전 스크립트
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mPosition = Input.mousePosition; //현재 마우스 좌표
		Vector3 oPosition = this.transform.position; //현재 오브젝트 좌표
		mPosition.z = Camera.main.transform.position.z + 2;
		Vector3 target = Camera.main.ScreenToWorldPoint (mPosition);//유니티 내에서 표현 가능 좌표로 변환

		if (target.x > oPosition.x) { //현재 마우스의 좌표가 캐릭터 기준으로 오른쪽에 있는가?
			this.transform.localScale = new Vector3 (-1, 1, 0); //맞으면 스프라이트 반전 
			reverse = true; //애니메이션 리버스 처리
		} else {
			this.transform.localScale = new Vector3 (1, 1, 0); //틀리면 그대로 
			reverse = false;
		}

		if (target.x == oPosition.x) //방향이 전환되는 시점에서 애니메이션 좌우 전환
		{	running = false;
		animator.SetBool ("Running", running);
		}

		animator.SetBool("reverse",reverse);

	}
}
