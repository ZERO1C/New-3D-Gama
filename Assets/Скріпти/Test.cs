using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Test : MonoBehaviour
{

    private Portal123 portal;
    public GameObject knight_bot;
    

    public GameObject[] building;
    public GameObject[] building_start;
    public GameObject building_zone;
    public int width;
    public int length;
    private int namber;
    private int[] random_genereit;
    private int start_point;
    private int taitl;
    private int stop;
    private int test_1;
    private int[] road;
    private int number_road=1;
    private int a;
    private int a_key;
    private int x_key;
    private int z_key;
    private int b;
    private int save;
    private int[] map;
    private int key;
    private int key2;
    private int number_map;
    public int[] map_bot;
    void Start()
    {







        namber = width * length;
        random_genereit = new int[namber];
        map = new int[namber];
        start_point = UnityEngine.Random.Range(0, width);
        start_point *= length;
        save = start_point;
        road = new int[namber / 2];
        
        if (start_point != 0)
        {
            road[0] = start_point;
        }

        
        map_bot = new int[namber / 2];

        random_genereit[start_point] = 1;
        //Debug.Log(random_genereit[start_point] + ";  start_point = " + start_point);
        



        for (int f = 0; f < namber - 1; f++)
        {
            random_genereit[start_point] = 1;
            
            if (start_point != road[number_road-1])
            {
                road[number_road] = start_point;
                number_road += 1;
            }
            


            
            
            taitl = UnityEngine.Random.Range(1, 4);
            if (taitl == 1)
            {
                if (start_point > length)
                {
                    int test = start_point - length;

                    if (test > length)
                    {
                        test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test + length] + random_genereit[test - length];
                    }
                    else
                    {
                        test_1 = 2;
                    }
                    /*
                    else
                    {
                        if (test > 1)
                        {
                            test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test + length];
                        }
                        else
                        {
                            test_1 = random_genereit[test + 1] + random_genereit[test + length];
                        }
                    }
                    */
                    //Debug.Log("Test = " + test + "test_1 = " + test_1);
                    if (test_1 == 1)
                    {
                        start_point = test;
                    }
                }

            }
            else if (taitl == 2)
            {
                if (start_point < namber - 1)
                {
                    if (start_point % length < length - 1) 
                    {
                        int test = start_point + 1;

                        if (test < namber - length && test > length)
                        {
                            test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test + length] + random_genereit[test - length];
                        }
                        else
                        {
                            test_1 = 2;
                        }
                        /*
                        else if (test > length)
                        {
                            if (test < namber - 1)
                            {
                                test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test - length];
                            }
                            else
                            {
                                test_1 = random_genereit[test - 1] + random_genereit[test - length];
                            }

                        }
                        else if (test < namber - length)
                        {
                            if (test > 1)
                            {
                                test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test + length];
                            }
                            else
                            {
                                test_1 = random_genereit[test + 1] + random_genereit[test + length];
                            }

                        }
                        */
                        //Debug.Log("Test = " + test + "test_1 = " + test_1);
                        if (test_1 == 1)
                        {
                            start_point = test;
                        }
                    }
                    
                }
            }
            else if (taitl == 3)
            {
                if (start_point < namber - length)
                {
                    int test = start_point + length;

                    if (test < namber - length)
                    {
                        test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test + length] + random_genereit[test - length];
                    }
                    else
                    {
                        test_1 = 2;
                    }
                    /*
                    else
                    {
                        if (test > namber - 1)
                        {
                            test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test - length];
                        }
                        else
                        {
                            test_1 = random_genereit[test - 1] + random_genereit[test - length];
                        }

                    }
                    */
                    //Debug.Log("Test = " + test + "test_1 = " + test_1);
                    if (test_1 == 1)
                    {
                        start_point = test;

                    }
                }

            }
            
        }
        for (int i = 0; i <= namber - 1; i++)
        {
            if (i == 0)
            {
                random_genereit[i] = 0;
            }
            if (random_genereit[i] == 0)
            {
                random_genereit[i] = 0;
                int point_zone_build_z = -(i / length) + 2;
                point_zone_build_z *= 4;
                int point_zone_build_x = i % length;
                point_zone_build_x *= 4;

                Instantiate(building_zone, new Vector3(point_zone_build_x, 0, point_zone_build_z), transform.rotation);
            }
            else if (random_genereit[i] == 1)
            {

                a = 0;
                if (i > 1) { a |= random_genereit[i - 1] << 3; } else { a |= 0 << 3; }                
                if (i < namber - 1) { a |= random_genereit[i + 1] << 2; } else { a |= 0 << 2; }                
                if (i > length) { a |= random_genereit[i - length] << 1; } else { a |= 0 << 1; }     
                if (i < namber - length) { a |= random_genereit[i + length]; } else { a |= 0; }
                map[i] = a;
                //Debug.Log("map[i] = " + map[i] + "  i =  " + i);


                int point_zone_build_z = -(i / length) + 2;
                point_zone_build_z *= 4;
                int point_zone_build_x = i % length;
                point_zone_build_x *= 4;

                if (0 == i%10 || i%10==1)
                {

                    //1248

                    Instantiate(building_start[a], new Vector3(point_zone_build_x, 0, point_zone_build_z), transform.rotation);
                }
                else
                {
                    Instantiate(building[a], new Vector3(point_zone_build_x, 0, point_zone_build_z), transform.rotation);

                    if (a == 1 || a == 2 || a == 4 || a == 8 )
                    {
                        //Portal123 portal123 = Instantiate(building[a], new Vector3(point_zone_build_x, 0, point_zone_build_z), transform.rotation).GetComponent<Portal123>();
                        //portal123.map_bot = 5;

                        /*
                        a_key = a;
                        x_key = point_zone_build_x;
                        z_key = point_zone_build_z;
                        */
                    }
                    else
                    {
                        
                    }

                    
                }

                

                //Debug.Log(i+"    "+a);
            }

        }

        for (int i = 1; i <= 1000; i++) 
        {

            if (road[i] == 0 && key == 0)
            {               
                //Debug.Log(i);
                
                key = 1;
            }
            if (key == 1)
            {
                number_map = i-1;                
                key = 2;                
            }
            if (key == 2)
            {
                
                if (number_map == 0)
                {
                    key = 3;
                    map_bot[b] = map[road[0]];
                    
                    
                }
                else
                {
                    map_bot[b] = map[road[number_map]];
                    number_map -= 1;
                    b += 1;

                }


                //Debug.Log("b =" + b + "   number_map = " + number_map + "  road = " + map[road[number_map]]);
            }
            if (i == namber/2-5)
            {
                i = 0;
            }
            if (key == 3)
            {
                i = 1001;   
                /*
                a = a_key;
                int point_zone_build_x = x_key;
                int point_zone_build_z = z_key;
                Portal123 portal123 = Instantiate(building[a], new Vector3(point_zone_build_x, 0, point_zone_build_z), transform.rotation).GetComponent<Portal123>();
                portal123.map_bot = 5;
                */
                
            }
        }




        //Debug.Log(" road = " + map[road[0]] + " map_bot[b] = " + map_bot[b]);


    }


    void Update()
    {
        //GameObject weapon_number = knight_bot.GetComponent<Run_bot>().myObekt;
    }
}
