using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboghostbehavior : MonoBehaviour
{
    GameObject player;

    bool dead;
    bool waking = true;
    bool dying = false;
    public bool hit;
    float dyingtime = 2;
    public float force;

    

    public Vector3 hitPos;
    Vector3 diff;
    Vector3 risingDiff;
    Vector3 diff2;
    Vector3 diff3;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player");
        hit = false;
        diff = player.transform.position - transform.position;
        risingDiff.x = transform.position.x;
        risingDiff.z = transform.position.z;
        risingDiff.y = player.transform.position.y;
        diff2 = risingDiff - transform.position;
        diff2 = Vector3.Normalize(diff2);


    }

    // Update is called once per frame
    void Update()
    {


        
        if (hit)
        {
            //hit = false;
           
        
            dead = true;
            diff = Vector3.Normalize(diff);
           
            diff.y = -.3f;
            //diff.x = diff.x ;
            //diff.z = diff.z ;
            // transform.GetComponent<Rigidbody>().AddForce(new Vector3(diff.x, .5f, diff.z), ForceMode.Impulse);
           
            transform.GetComponent<Rigidbody>().AddForceAtPosition(-diff/3, hitPos, ForceMode.Force);
            dying = true;
            if (dying)
            {
                transform.GetComponent<Rigidbody>().detectCollisions = false;
                dyingtime -= Time.deltaTime;
                if (dyingtime <= 0)
                {
                    Destroy(transform.gameObject);
                }
                
            }
        }
     
        if (!dead && !waking)
        {
            
            diff = player.transform.position - transform.position;
            transform.position = transform.position + (diff * Time.deltaTime);
        }

        if(waking)
        {
           
            transform.position = transform.position + (diff2 * Time.deltaTime);
     
            float dist = Vector3.Distance(risingDiff, transform.position);
            if(dist < 0.5)
            {
                waking = false;
            }

        }

        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "desk" )
        {
            transform.GetComponent<Rigidbody>().detectCollisions = false;
        }

        if( col.gameObject.tag == "protoroboghost")
        {
            transform.GetComponent<Rigidbody>().detectCollisions = false;
            var dist = transform.position - col.gameObject.transform.position;
            transform.position = transform.position + (dist * Time.deltaTime);
        }




    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "desk" || col.gameObject.tag == "protoroboghost")
        {
            transform.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }
}
