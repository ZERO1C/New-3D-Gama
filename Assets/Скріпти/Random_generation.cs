using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_generation : MonoBehaviour
{
    public GameObject building_zone;
    public int test;
    public int length;
    private int length_old;
    public int diameter;
    private int radius;
    private int square;
    private Vector3 point_position;
    private int Random_taitl;
    public GameObject[] object_;
    public int[] start;
    public int[] turn0;
    public int[] turn1;
    public int[] turn2;
    public int[] turn3;
    public int[] road_up;
    public int[] road_down;
    public int[] road90;
    private int[] map;
    private int save;
    private int point_map;

    void Start()
    {

        square = diameter * length;
        map = new int [square];
        diameter = (diameter - 1) * 2;
        length_old = length;
        length = length * 4 - 4;

        radius = diameter / 4;



        for (int i = 1; i <= square; i++)
        {
            if (test == 7)
            {

            }
            else
            {
                Instantiate(object_[test], point_position, transform.rotation);
                point_map =Mathf.RoundToInt((point_position.z / 4 - radius) * (-length_old) + point_position.x / 4);

                Debug.Log("point" + point_map + "z" + point_position.z + "x" + point_position.x);
                map[point_map] = 1;
            }
            
            if (test == 0)
            {
                if (point_position.x > length)
                {
                    test = 7;
                }
                else if (point_position.z == diameter - 4)
                {                    
                    test = 2;                    
                }
                else
                {
                    Random_taitl = Random.Range(0, 2);
                    test = turn0[Random_taitl];                    
                }
                save = 0;
                point_position += new Vector3(0, 0, 4);
            }
            else if (test == 1)
            {
                if (point_position.x >= length)
                {
                    test = 7;
                }
                else if (point_position.z == - diameter)
                {
                    Random_taitl = Random.Range(0, 2) + 1;
                    test = turn1[Random_taitl];
                }
                else
                {
                    Random_taitl = Random.Range(0, 3);
                    test = turn1[Random_taitl];
                }
                
                point_position += new Vector3(4, 0, 0);
            }
            //2
            else if (test == 2)
            {
                if (point_position.x >= length)
                {
                    test = 7;
                }
                else if (point_position.z == diameter)
                {
                    Random_taitl = Random.Range(0, 2);
                    test = turn2[Random_taitl];
                    
                }
                else
                {
                    Random_taitl = Random.Range(0, 3);
                    test = turn2[Random_taitl];
                    
                }
                point_position += new Vector3(4, 0, 0);
            }
            else if (test == 3)
            {
                if (point_position.x > length)
                {
                    test = 7;
                }
                else if (point_position.z == -diameter + 4)
                {
                    test = 1;
                }
                else
                {
                    Random_taitl = Random.Range(0, 2);
                    test = turn3[Random_taitl];
                }                
                point_position += new Vector3(0, 0, -4);
                save = 1;
            }
            else if (test == 4)
            {
                if (save == 0)
                {
                    if (point_position.x > length)
                    {
                        test = 7;
                    }
                    else if (point_position.z == diameter - 4)
                    {
                        test = 2;
                    }
                    else
                    {
                        Random_taitl = Random.Range(0, 2);
                        test = road_up[Random_taitl];
                    }
                    point_position += new Vector3(0, 0, 4);
                }
                else if (save == 1)
                {
                    if (point_position.x > length)
                    {
                        test = 7;
                    }
                    else if(point_position.z == -diameter + 4)
                    {
                        test = 1;
                    }
                    else
                    {
                        Random_taitl = Random.Range(0, 2);
                        test = road_down[Random_taitl];
                    }

                    point_position += new Vector3(0, 0, -4);
                }
               
            }
            //5
            else if (test == 5)
            {
                if (point_position.x >= length)
                {
                    test = 7;
                }
                else if (point_position.z == diameter)
                {
                    Random_taitl = Random.Range(0, 2);
                    test = road90[Random_taitl];

                }
                else if (point_position.z == -diameter)
                {
                    Random_taitl = Random.Range(0, 2) + 1;
                    test = road90[Random_taitl];
                }
                else
                {
                    Random_taitl = Random.Range(0, 3);
                    test = road90[Random_taitl];

                }
                point_position += new Vector3(4, 0, 0);

                
            }
            

        }
        for (int i = 0; i <= square -1; i++)
        {
            if (map[i] == 0)
            {
                map[i] = 2;
                int point_zone_build_z = -(i / length_old)+2;
                point_zone_build_z *= 4;
                int point_zone_build_x = i % length_old;
                point_zone_build_x *= 4;

                Instantiate(building_zone,new Vector3 (point_zone_build_x, 0, point_zone_build_z), transform.rotation);
            }
            else if (map[i] == 1)
            {

            }
        }





    }


    void Update()
    {

    }
}
