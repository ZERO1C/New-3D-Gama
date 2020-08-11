using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_Cam : MonoBehaviour
{
    public GameObject object1;
    private float rout;
    public float moveX, moveY;
    public float SensX, SensY;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJoint hinge = gameObject.GetComponentInParent(typeof(HingeJoint)) as HingeJoint;
        //HingeJoint hinge = gameObject.GetComponentInParent<HingeJoint>();
        
    }

    public Vector2 MinMax_Y,
                  MinMax_X;

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle -= 360F;
        if (angle > 360F) angle += 360F;
        return Mathf.Clamp(angle, min, max);
    }
    // Update is called once per frame
    void Update()
    {
        rout = gameObject.GetComponentInParent<Archer>().rout;
        moveY -= Input.GetAxis("Mouse Y") * SensY;

        moveY = ClampAngle(moveY, MinMax_Y.x, MinMax_Y.y);
        moveX += Input.GetAxis("Mouse X") * SensX;

        moveX = ClampAngle(moveX, MinMax_X.x, MinMax_X.y);
        //Debug.Log(rout);
        gameObject.transform.rotation = Quaternion.Euler(moveY, rout, 0);
    }
    /*private Vector3 lastMouse = new Vector3(255, 255, 255);
    float camSens = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //Debug.Log(gameObject.transform.rotation.y);
        
        
            
        if (lastMouse.y <= 800 && lastMouse.y >= 100)
        {
            Debug.Log("1  "+lastMouse);
            lastMouse = Input.mousePosition - lastMouse;
            Debug.Log("2  " + lastMouse);
            lastMouse = new Vector3(-lastMouse.y * camSens, 0, 0);
            //Debug.Log(transform.eulerAngles.y + lastMouse.y + "    ;    " + transform.eulerAngles.y + "    ;    m " + lastMouse.y);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;
            lastMouse = Input.mousePosition;
        }
        else if (lastMouse.y > 800)
        {
            
            lastMouse = Input.mousePosition - lastMouse;
            if (lastMouse.y < 0)
            {
                Debug.Log("2  " + lastMouse);
                lastMouse = new Vector3(-lastMouse.y * camSens, 0, 0);
                //Debug.Log(transform.eulerAngles.y + lastMouse.y + "    ;    " + transform.eulerAngles.y + "    ;    m " + lastMouse.y);
                lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
                transform.eulerAngles = lastMouse;
                lastMouse = Input.mousePosition;
            }

            
        }
        else if (lastMouse.y < 100)
        {
            lastMouse = Input.mousePosition - lastMouse;
            if (lastMouse.y > 0)
            {
                Debug.Log("2  " + lastMouse);
                lastMouse = new Vector3(-lastMouse.y * camSens, 0, 0);
                //Debug.Log(transform.eulerAngles.y + lastMouse.y + "    ;    " + transform.eulerAngles.y + "    ;    m " + lastMouse.y);
                lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
                transform.eulerAngles = lastMouse;
                lastMouse = Input.mousePosition;
            }
        }



    }*/
}
