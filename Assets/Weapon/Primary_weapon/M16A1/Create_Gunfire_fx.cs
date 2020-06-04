using UnityEngine;
using System.Collections;

public class Create_Gunfire_fx : MonoBehaviour
{
    public GameObject Gunfirefx;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void fire_on()
    {
        Instantiate(Gunfirefx, this.transform.position, Quaternion.identity);
    }
}
