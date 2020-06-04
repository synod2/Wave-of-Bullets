using UnityEngine;
using System.Collections;

public class Boost_fx_script : MonoBehaviour { //부스터 이펙트 컨트롤러
    int timer = 0;
    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        timer++;
        if (timer == 80)
            Destroy(gameObject);
       // Debug.Log(timer+" destime");


	}
}
