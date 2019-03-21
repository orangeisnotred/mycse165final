using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxscriptV2 : MonoBehaviour
{
	GameObject rightHand;
	GameObject bPplace;
	GameObject bPObj;
	GameObject bPObjPosition;
	string putCubePositionNumber;
	
	float upTime;
	
	bool inBP = false;
	bool holdObj = false;
	static bool haveObjectInhand = false;
	
	void OnTriggerStay(Collider col)
    {
        // Debug.Log("collided");
        if (col.gameObject.tag == "right")
        {
            if (rightHand.transform.GetComponent<Raycasttest>().isHolding)
            {
				if(!haveObjectInhand)
				{
					holdObj = true;
				}
				haveObjectInhand = true;
				
            }
			else
			{	
				holdObj = false;
				haveObjectInhand = false;
				
			}
			// Debug.Log("Stay");
			
			if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) && leftHandScript.putStuffInBP)
			{
				// Debug.Log(inBP);
				if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
				{	
					GameObject temp = GameObject.Find("/backPackObj"+ leftHandScript.backPackBox.ToString());
					if (temp.transform.childCount == 0)
					{
						// upTime = Time.time;
						putCubePositionNumber = leftHandScript.backPackBox.ToString();
						
						inBP = true;
						holdObj = false;
						haveObjectInhand = false;
					}
					
					
					
				}
			}
		
        }

    }
	
	
    // Start is called before the first frame update
    void Start()
    {
        rightHand = GameObject.Find("hand_right");
		bPObj = GameObject.Find("/backPackObj");
		upTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
	

		if (holdObj)
		{

			transform.parent = bPObj.transform.parent;
			transform.position = rightHand.transform.position;
			transform.rotation = rightHand.transform.rotation;
			transform.localScale = new Vector3(0.05f,0.05f,0.05f); 
			inBP = false;
			transform.GetChild(0).GetComponent<Light>().range = 1;
		}
		else
		{
			if (inBP)
			{
				if(GameObject.Find("/backPack(Clone)") != null)
				{
					bPObjPosition = GameObject.Find("/backPackObj"+ putCubePositionNumber);	
					bPplace = GameObject.Find("/backPack(Clone)/Panel/group/"+ putCubePositionNumber+"/light");
				}
				
				transform.parent = bPObjPosition.transform;				
				transform.localScale = new Vector3(1f,1f,1f);
				transform.position = bPplace.transform.position + new Vector3(0,0,0.02f);
				transform.GetChild(0).GetComponent<Light>().range = 0;
			}
			else
			{
				transform.parent = bPObj.transform.parent;
				transform.localScale = new Vector3(0.2f,0.2f,0.2f); 
				transform.GetChild(0).GetComponent<Light>().range = 2;
			}
		}

        
		
		
		
		
    }
	
	
	
	
	
	
}
