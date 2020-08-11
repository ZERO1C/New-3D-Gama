using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_generation_1 : MonoBehaviour
{
    public GameObject building_zone;
    public int width;
    public int length;
    private int namber;
    private int[] random_genereit;
    private int start_point;
    private int taitl;
    private int stop;
    private int test_1;
    void Start()
    {
        namber = width * length;
        random_genereit = new int [namber];
        start_point = Random.Range(0, width);
        start_point *= length;



        for (int f = 0; f < namber - 1; f++) 
        {


            random_genereit[start_point] = 1;
            taitl = Random.Range(1, 4);
            if (taitl == 1)
            {
                if (start_point > length)
                {
                    int test = start_point - length;
                    Debug.Log(test);
                    if (test > length)
                    {
                        test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test + length] + random_genereit[test - length];
                    }
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
                    if (test_1 == 1) 
                    {
                        start_point = test;
                    }
                }
                
            }
            else if (taitl == 2)
            {
                if (start_point < namber-1)
                {
                    int test = start_point + 1;
                    Debug.Log(test);
                    if (test < namber - length && test > length)
                    {
                        test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test + length] + random_genereit[test - length];
                    }
                    else if (test > length)
                    {
                        if(test < namber - 1)
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
                        test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test + length];
                    }
                    if (test_1 == 1)
                    {
                        start_point = test;
                    }
                }
            }
            else if (taitl == 3)
            {
                if (start_point < namber- length)
                {
                    int test = start_point + length;
                    Debug.Log(test);
                    if (test < namber - length)
                    {
                        test_1 = random_genereit[test + 1] + random_genereit[test - 1] + random_genereit[test + length] + random_genereit[test - length];
                    }
                    else
                    {
                        if (test < namber - 1)
                        {
                            test_1 = random_genereit[test + 1] + random_genereit[test - 1]  + random_genereit[test - length];
                        }
                        else
                        {
                            test_1 = random_genereit[test - 1]  + random_genereit[test - length];
                        }
                        
                    }
                    
                    if (test_1 == 1)
                    {
                        start_point = test;
                    }
                }
                    
            }



            //int Namber_taitl = Random.Range(0, 2);
            //random_genereit[f] = Namber_taitl;
            //Debug.Log(random_genereit);
        }
        for (int i = 0; i <= namber - 1; i++)
        {
            if (random_genereit[i] == 0)
            {
                random_genereit[i] = 2;
                int point_zone_build_z = -(i / length) + 2;
                point_zone_build_z *= 4;
                int point_zone_build_x = i % length;
                point_zone_build_x *= 4;

                Instantiate(building_zone, new Vector3(point_zone_build_x, 0, point_zone_build_z), transform.rotation);
            }
            else if (random_genereit[i] == 1)
            {

            }
        }

    }


    void Update()
    {
        
    }
}
