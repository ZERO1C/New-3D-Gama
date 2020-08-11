using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_bot : MonoBehaviour
{
    public float speed;
    private Vector3 p_Velocity;
    public GameObject knight;
    public GameObject myObekt;
    public int i;
    public int k;
    public int[] map;
    //                        0  1  2 3 4  5  6 7  8  9 10 11 12 3 4 5    0 1  2 3 4  5 6 7  8 9 10 1 2 3 4 5   0  1   2  3 4  5   6  7  8   9   10 1 2 3 4 5    0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5
    public int[,] map_key= { {0,-2,-2,0,-4,-2,-2,0,-2,-2,-2,0,-4,0,0,0 },{ 0,2,-2,4,0,-2,2,0,-2,2,-2,0,0,0,0,0},{0,-90, 90,0,0,-90, 90,0,-90,-90,90,0,0,0,0,0 },{1,2,2,2,1,1,1,1,1,2,2,1,1,1,1,1 }  };
    private int number;
    private int key;
    private int X_run;
    private int Z_run;
    private int rot_run;
    private Rigidbody Fithic;
    private float time;
    private float stop_x=2;
    private float stop_Z=0;
    private float progress;
    public Vector3 pzihon;

    private int key_run_1 = -1;
    public int key_run_2;
    private int key_run_3;
    private int key_run_4;
    public float hp;
    //public float damage;
    void Start()
    {
        stop_Z = transform.position.z;
        stop_x = transform.position.x;
        


        //myObekt = gameObject;
        //map_key = new int[4,16];
        //map_key[0, 1] = 1;
        //Fithic = knight.GetComponent<Rigidbody>();
        

        //Debug.Log(" stop_Z = " + stop_Z);
        //Debug.Log(" stop_x = " + stop_x);
        //Debug.Log(" X_run = " + X_run);
        //Debug.Log(" Z_run = " + Z_run);
    }

    void FixedUpdate()
    {
        //Debug.Log(hp);



        if (key_run_1 == -1)
        {
            if (key_run_2 == 1)
            {
                rot_run = 0;
            }
            else if (key_run_2 == 2)
            {
                rot_run = -180;
            }
            else if (key_run_2 == 3)
            {
                rot_run = -90;
            }
            key_run_1 = 3;      
        }
        

        if(key_run_1 == 3)
        {
            



            i += 1;
            //Debug.Log("map[i] = " + map[i]);
            key = map[i];
            //Debug.Log("key = "+key);
            X_run = map_key[0, key];
            Z_run = map_key[1, key];
            rot_run += map_key[2, key];
            number = map_key[3, key];
            //Debug.Log(map_key[2, key]);
            stop_x += X_run;
            if (Z_run == 4 && key_run_2 == 2)
            {
                stop_Z -= Z_run;
            }
            else
            {
                stop_Z += Z_run;
            }

            key_run_1 = 0;
        }


        
        if (key != 0)
        {
            if (number == 1)
            {
                if (transform.position.x < stop_x + 0.15f && transform.position.x > stop_x - 0.15f && key_run_1 == 0)
                {
                    key_run_1 = 1;

                }
                else if (key_run_1 == 0)
                {
                    run_forward();
                    key_run_2 = 1;
                    //Debug.Log(6);
                }
                if (key_run_1 == 1)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, rot_run, 0);
                    key_run_1 = 2;
                }
                if (key_run_1 == 2)
                {
                    //Debug.Log(2);
                    if (transform.position.z < stop_Z + 0.15f && transform.position.z > stop_Z - 0.15f)
                    {

                        key_run_1 = 3;

                    }
                    else
                    {
                        //Debug.Log(4 + "  " + speed); 
                        run_right();
                        if (Z_run == 2)
                        {
                            key_run_2 = 1;
                        }
                        else if (Z_run == -2)
                        {
                            key_run_2 = 2;
                        }

                    }
                }


            }
            if (number == 2)
            {
                if (transform.position.z < stop_Z + 0.15f && transform.position.z > stop_Z - 0.15f && key_run_1 == 0)
                {
                    key_run_1 = 1;


                }
                else if (key_run_1 == 0)
                {
                    if (Z_run == 4)
                    {

                        if (key_run_2 == 1)
                        {
                            //Debug.Log(key_run_2);
                            Z_run = 2;
                            run_right();
                        }
                        else if (key_run_2 == 2)
                        {
                            //Debug.Log(key_run_2);
                            Z_run = -2;
                            run_right();
                        }
                    }
                    else
                    {
                        run_right();
                    }


                    //Debug.Log(5);
                }
                if (key_run_1 == 1)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, rot_run, 0);
                    key_run_1 = 2;
                }
                if (key_run_1 == 2)
                {
                    //Debug.Log(1);
                    if (transform.position.x < stop_x + 0.15f && transform.position.x > stop_x - 0.15f)
                    {

                        key_run_1 = 3;

                    }
                    else
                    {
                        //Debug.Log(3+"  "+ speed);
                        run_forward();

                    }
                }

            }
        }

        
        


    }
    public void Damage(float damage)
    {
        Debug.Log(150);
        if (hp<0)
        {
            Destroy(gameObject);
        }

        hp -= damage;



    }
    void run_right()
    {

        // Debug.Log(9);
        Vector3 route = transform.InverseTransformDirection((new Vector3(0, 0, Z_run) * Time.deltaTime * speed));
        transform.Translate(route);
    }
    void run_left()
    {
        //Debug.Log(8);
        Vector3 route = transform.InverseTransformDirection((new Vector3(0, 0, -2) * Time.deltaTime * speed));
        transform.Translate(route);
    }
    void run_forward()
    {

        //Debug.Log(7);
        Vector3 route = transform.InverseTransformDirection((new Vector3(-2, 0, 0) * Time.deltaTime * speed));
        transform.Translate(route);
    }
}
