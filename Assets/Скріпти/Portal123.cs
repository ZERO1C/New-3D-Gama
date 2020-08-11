using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal123 : MonoBehaviour
{
    public int point;
    public GameObject obj;

    public int[] map;
    public int map_bot;
    private int i = 0;




    void Start()
    {
        // Найти объект по имени
        GameObject go = GameObject.FindWithTag("Generat");
        // взять его компонент где лежит скорость
        Test speedController = go.GetComponent<Test>();
        // взять переменную скорости
        map = speedController.map_bot;

        if(point==1)
        {
            Run_bot run_bot = Instantiate(obj, new Vector3(transform.position.x, 0.645f, transform.position.z+2), transform.rotation).GetComponent<Run_bot>();
            run_bot.map = map;
            run_bot.key_run_2 = 1;
        }
        else if (point == 2)
        {
            Run_bot run_bot = Instantiate(obj, new Vector3(transform.position.x-2, 0.645f, transform.position.z), transform.rotation).GetComponent<Run_bot>();
            run_bot.map = map;
            run_bot.key_run_2 = 3;
        }
        else if (point == 3)
        {
            Run_bot run_bot = Instantiate(obj, new Vector3(transform.position.x, 0.645f, transform.position.z-2), transform.rotation).GetComponent<Run_bot>();
            run_bot.map = map;
            run_bot.key_run_2 = 2;
        }
        else if (point == 4)
        {
            Run_bot run_bot = Instantiate(obj, new Vector3(transform.position.x, 0.645f, transform.position.z), transform.rotation).GetComponent<Run_bot>();
            run_bot.map = map;
        }


        StartCoroutine(instObj());
        Invoke("Inst", 2f);
    }
      

    void Update()
    {
        //Portal123 portal123 = Instantiate(building[a], new Vector3(point_zone_build_x, 0, point_zone_build_z), transform.rotation).GetComponent<Portal123>();
    }

    IEnumerator instObj()
    {

        yield return new WaitForSeconds(1.5f);
        
            
        
    }
}
