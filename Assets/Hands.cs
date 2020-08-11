﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    
    public float rout;
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
        Debug.Log(rout);
        gameObject.transform.rotation = Quaternion.Euler(moveY, rout, 0);
        Debug.Log(moveY);
    }
}
