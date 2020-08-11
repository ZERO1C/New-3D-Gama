using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{



    public float slope;
    public float rout;
    public GameObject point_spawn;
    public GameObject Arrow;
    public float reload_start;
    private float reload;

    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        rout = gameObject.GetComponentInParent<Archer>().rout;
        slope = gameObject.GetComponentInParent<Head_Cam>().moveY;
        //Debug.Log(rout);
        //Debug.Log(slope);
        if (Input.GetMouseButton(1) && reload < 0)
        {
            arrow arrow = Instantiate(Arrow, point_spawn.transform.position, transform.rotation).GetComponent<arrow>();
            arrow.rout = rout;
            arrow.slope = slope;
            reload = reload_start;
        }
        else
        {
            reload -= Time.fixedDeltaTime;
        }
    }
    
}
