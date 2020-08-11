using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{



    public float slope;
    public float rout;
    public GameObject point_spawn;
    public GameObject Arrow;
    public Collider[] parentCollider;
    public float reload_start;
    private float reload;

    void Update()
    {
        rout = gameObject.GetComponentInParent<Archer>().rout;
        slope = gameObject.GetComponentInParent<Head_Cam>().moveY;
        //Debug.Log(rout);
        //Debug.Log(slope);
        if ((Input.GetMouseButton(1) || Input.GetKeyDown(KeyCode.Space)) && reload < 0) {
            arrow arrow = Instantiate(Arrow, point_spawn.transform.position, Quaternion.Euler(slope, rout, 0)).GetComponent<arrow>();
            arrow.rout = rout;
            arrow.slope = slope;
            reload = reload_start;

            for (int i = 0; i < parentCollider.Length; ++i) {
                Physics.IgnoreCollision(arrow.collider, parentCollider[i]);
            }
        }
        else {
            reload -= Time.fixedDeltaTime;
        }
    }

    private void FixedUpdate()
    {
        
    }
    
}
