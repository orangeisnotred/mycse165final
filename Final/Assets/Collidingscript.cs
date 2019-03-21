using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidingscript : MonoBehaviour
{
    public static bool collisionOne;
   // GameObject firstSet;
    public GameObject set;
    // Start is called before the first frame update
    void Start()
    {
        collisionOne = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            collisionOne = true;
           // firstSet = GameObject.Find("firstSet");
            Debug.Log("collided");
            foreach (Transform child in set.transform)
            {
                child.gameObject.SetActive(true);
               
            }
            //firstSet.transform.FindChild("protoroboghost").
        }

        

    }
}
