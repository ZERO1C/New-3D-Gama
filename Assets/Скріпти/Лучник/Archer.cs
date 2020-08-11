using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public float speed;
    Vector3 route_z;
    Vector3 route_x;
    

    float moveX, moveY;
    public float SensX , SensY ;


    public Vector2 MinMax_Y ,
              MinMax_X ;

    public float rout;
    public void Start()
    {
        
        
    }
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle -= 360F;
        if (angle > 360F) angle += 360F;
        return Mathf.Clamp(angle, min, max);
    }
    public void FixedUpdate()
    {


        moveY -= Input.GetAxis("Mouse Y") * SensY;

        moveY = ClampAngle(moveY, MinMax_Y.x, MinMax_Y.y);
        moveX += Input.GetAxis("Mouse X") * SensX;
        gameObject.transform.rotation = Quaternion.Euler(moveY, moveX, 0);
        rout = moveX;

        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(new Vector3(0, 0, 1) * Time.fixedDeltaTime * speed);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * Time.fixedDeltaTime * speed);

        }
        
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.fixedDeltaTime * speed);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.fixedDeltaTime * speed);
        }
        
        
        












    }
    
}
