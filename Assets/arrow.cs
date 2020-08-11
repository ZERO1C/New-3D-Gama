using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float rout;

    public int speed;
    public float time;
    public float time2_start;
    private float time2;
    public float speed_y;

   
    //public float lifitime;
    public float distance;
    public Vector2 pushing;

    public LayerMask whatIsSolid;
    public float slope;
    public float damage;
    private float start_distans_x;
    private float start_distans_z;
    private float finih_distans_x;
    private float finih_distans_z;
    private float distans;
    private float rout_2;

    void Start()
    {
        start_distans_x = gameObject.transform.position.x;
        start_distans_z = gameObject.transform.position.z;
    }


    private void FixedUpdate()
    {
        finih_distans_x = gameObject.transform.position.x;
        finih_distans_z = gameObject.transform.position.z;

        distans = Mathf.Sqrt(Mathf.Pow((finih_distans_x - start_distans_x), 2) + Mathf.Pow((finih_distans_z - start_distans_z), 2)) ;
        

        /*RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, whatIsSolid);
        Debug.Log(hitInfo);
        if (hitInfo.collider != null)
        {
            Debug.Log(1);
            if (hitInfo.collider.CompareTag("Bot"))
            {
                hitInfo.collider.GetComponent<Run_bot>().Damage(damage);
            }
            Destroy(gameObject);
        }*/

        
        transform.Translate(new Vector3(0, 0, 1) * Time.fixedDeltaTime * speed);
        
        time2 -= Time.fixedDeltaTime;
        time -= Time.fixedDeltaTime;
        if (time < 0)
        {
            Destroy(gameObject);
        }
        if (time2 <= 0)
        {
            
            time2 = time2_start;
        }
        rout_2 = slope + 1 * distans;

        gameObject.transform.rotation = Quaternion.Euler(rout_2, rout, 0);
    }
    /*private void OnTriggerEnter(Collider collision)
    {
        Run_bot run_bot = collision.GetComponent<Run_bot>();
        if (run_bot != null)
        {
            run_bot.Damage(damage);
        }
        Destroy(gameObject);
    }*/
    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);
    }


}
