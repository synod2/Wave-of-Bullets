using UnityEngine;
using System.Collections;

public class E_Bullet_move : MonoBehaviour {
    Vector3 direction;
    Vector3 pPosition;
    public float speed = 1000.0f;
    public float d_t = Time.deltaTime;

    GameObject Body;
    // Use this for initialization
    void Start () {
        Body = this.gameObject;
        pPosition = GameObject.FindGameObjectWithTag("Player").transform.position; //현재 플레이어 위치
        
        Vector3 heading = pPosition - Body.transform.position;
        var distance = heading.magnitude;
        direction = heading / distance; // This is now the normalized direction
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * speed * d_t * 15);

        if (Vector3.Distance(this.transform.position, pPosition) > 10)
        {
            Destroy(gameObject);
        }
    }
}
