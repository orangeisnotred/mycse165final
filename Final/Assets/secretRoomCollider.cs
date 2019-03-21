using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretRoomCollider : MonoBehaviour
{
	bool holdObj = false;
	static bool haveObjectInhand = false;
    public float mod;
	Quaternion handRotationInit;
	Quaternion objectRotationInit;
	GameObject rightHand;
	float Nowz;
	float Initz;
	bool collided = false;
	bool exit = true;
	bool valid;
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
					
					float handAngleInitz = handRotationInit.eulerAngles.z;
					if (handAngleInitz <=360 && handAngleInitz >180)
					{
						Initz = handAngleInitz - 360;
					}
					else
					{
						Initz = handAngleInitz;
					}
					
					
				}
				haveObjectInhand = true;
				
				if (holdObj && collided)
				{	
					// Quaternion handRot =  rightHand.transform.localRotation * Quaternion.Inverse(handRotationInit);
					// Vector3 handRotAngle = handRot.eulerAngles;
					
					
					float handAngleNowz = rightHand.transform.localRotation.eulerAngles.z;
					
					
					if (handAngleNowz <=360 && handAngleNowz >200)
					{
						Nowz = handAngleNowz - 360;
						valid = true;
					}
					else if (handAngleNowz <=160 && handAngleNowz >=0)
					{
						Nowz = handAngleNowz;
					}
					else
					{
						valid = false;
					}
					// else if (handAngleNowz <=200 && handAngleNowz > 180)
					// {
						// Nowz = 200 - 360;
					// }
					// else
					// {
						// Nowz = 160;
					// }
					
					if (valid)
					{
						float z = Nowz - Initz;
						// Debug.Log("handAngleInit.z: "+Initz);
						// Debug.Log("handAngleNow.z: "+Nowz);
						// Debug.Log("z: "+z);
						

						// Quaternion finRot = (Quaternion.Slerp(objectRotationInit, Quaternion.Euler(0, 0, z) * objectRotationInit, mod));
						
						transform.localRotation = Quaternion.Euler(0, 0, -z) * objectRotationInit;

						// Debug.Log(transform.localRotation.eulerAngles);
					}
					
				}
		
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
		// collided = false;
        // holdObj = false;
		// haveObjectInhand = false;

    }
	
    // Start is called before the first frame update
    void Start()
    {
        rightHand = GameObject.Find("hand_right");
    }

    // Update is called once per frame
    void Update()
    {
		// if (holdObj && collided)
		// {	
			// // Quaternion handRot =  rightHand.transform.localRotation * Quaternion.Inverse(handRotationInit);
			// // Vector3 handRotAngle = handRot.eulerAngles;
			
			
			// float handAngleNowz = rightHand.transform.localRotation.eulerAngles.z;
			
			
			// if (handAngleNowz <=360 && handAngleNowz >200)
			// {
				// Nowz = handAngleNowz - 360;
			// }
			// else if (handAngleNowz <=160 && handAngleNowz >=0)
			// {
				// Nowz = handAngleNowz;
			// }
			// else if (handAngleNowz <=200 && handAngleNowz > 180)
			// {
				// Nowz = 200 - 360;
			// }
			// else
			// {
				// Nowz = 160;
			// }
			
			
			// float z = Nowz - Initz;
			// Debug.Log("handAngleInit.z: "+Initz);
			// Debug.Log("handAngleNow.z: "+Nowz);
			// Debug.Log("z: "+z);
			

            // Quaternion finRot = (Quaternion.Slerp(objectRotationInit, Quaternion.Euler(0, 0, z) * objectRotationInit, mod));
            // transform.localRotation = finRot;

            // Debug.Log(rightHand.transform.localRotation.eulerAngles);
		// }
        
    }
}
