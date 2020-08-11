using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Cont : MonoBehaviour
{
    public float speed;
    private Vector3 p_Velocity;
    private Vector3 p_Velocity_z;
    private Vector3 p_Velocity_x;
    private Vector3 p_Velocity_y;
    private Vector3 lastMouse = new Vector3(255, 255, 255);
    float camSens = 0.25f;
    private Rigidbody Fithic;
    public void Start()
    {
        Fithic = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        

        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;

        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity_z = new Vector3(0, 0, 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            p_Velocity_z = new Vector3(0, 0, -1);
        }
        else
        {
            p_Velocity_z = new Vector3( 0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity_x = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            p_Velocity_x = new Vector3(1, 0, 0);
        }
        else
        {
            p_Velocity_x = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            p_Velocity_y = new Vector3(0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            p_Velocity_y = new Vector3(0, -1, 0);
        }
        else
        {
            p_Velocity_y = new Vector3(0, 0, 0);
        }

        p_Velocity = p_Velocity_z + p_Velocity_x + p_Velocity_y;
        Fithic.velocity=transform.TransformDirection(p_Velocity * Time.fixedDeltaTime * speed);







    }

}
