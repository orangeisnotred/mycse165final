using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotPuzzle2 : MonoBehaviour
{
    bool holdObj = false;
    bool stored = false;
    static bool haveObjectInhand = false;
    public float mod;
    Quaternion handRotationInit;
    Quaternion objectRotationInit;
    Quaternion initialRot;
    Quaternion newRot;
    GameObject rightHand;

    bool collided = false;
    void OnTriggerStay(Collider col)
    {
        collided = true;
        // Debug.Log("collided");
        if (col.gameObject.tag == "right")
        {

            if (rightHand.transform.GetComponent<Raycasttest>().isHolding)
            {
     
                    holdObj = true;
           
            }
            else
            {
                holdObj = false;
          
            }


        }

    }
    void OnTriggerExit(Collider col)
    {
        collided = false;
      
       

    }

    // Start is called before the first frame update
    void Start()
    {
        rightHand = GameObject.Find("hand_right");
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) == 0.0f)
        {
            holdObj = false;
            collided = false;
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f  && collided)
        {
            holdObj = true;
        }

        if (!holdObj)
        {
            stored = false;
        }

        if (holdObj && collided)///////////////Main Rotation
        {

            if (!stored && collided)
            {

                handRotationInit.Set(rightHand.transform.localRotation.x, rightHand.transform.localRotation.y, rightHand.transform.localRotation.z, rightHand.transform.localRotation.w);
                stored = true;
            }

            newRot.Set(rightHand.transform.localRotation.x, rightHand.transform.localRotation.y, rightHand.transform.localRotation.z, rightHand.transform.localRotation.w);

            Quaternion diff = newRot * Quaternion.Inverse(handRotationInit);


            //{
            //    diff = Quaternion.AngleAxis(170, Vector3.up);




            Quaternion finRot = (Quaternion.Slerp(transform.localRotation, transform.localRotation * diff, 0.07f));
            transform.localRotation = finRot;/////////////////////ROTATION DISABLE
            transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, transform.localRotation.eulerAngles.z));

        }


     

    }
}
