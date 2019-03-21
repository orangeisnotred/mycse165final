using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRPfish : MonoBehaviour
{
	bool holdObj = false;
	static bool haveObjectInhand = false;
	
	Quaternion handRotationInit;
	Quaternion objectRotationInit;
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
				if(!haveObjectInhand)
				{
					handRotationInit = rightHand.transform.localRotation;
					objectRotationInit = transform.localRotation;
					holdObj = true;
				}
				haveObjectInhand = true;
            }
			else
			{
				holdObj = false;
				haveObjectInhand = false;
			}
		
		
        }

    }
	void OnTriggerExit(Collider col)
    {
		collided = false;
        holdObj = false;
		haveObjectInhand = false;

    }
	
    // Start is called before the first frame update
    void Start()
    {
        rightHand = GameObject.Find("hand_right");
    }

    // Update is called once per frame
    void Update()
    {
		if (holdObj && collided)
		{	
			Quaternion handRot =  rightHand.transform.localRotation  * Quaternion.Inverse(handRotationInit);
			Vector3 handRotAngle = handRot.eulerAngles;
			Debug.Log(handRot.eulerAngles);
			transform.localRotation = Quaternion.Euler(0, 0, -handRotAngle.z) * objectRotationInit;		
		}
        
    }
}
