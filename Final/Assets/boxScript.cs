using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    public bool isHeld;
    GameObject rightHand;
	Vector3 orignalSize;
	GameObject bPplace;
	GameObject bPObj;
	
	bool inBP;
	string putRedBoxNum = "1";
    // Start is called before the first frame update
    void Start()
    {
        isHeld = true;
		inBP = false;
		orignalSize = new Vector3(0.3f,0.3f,0.3f); 
		// bPplace = GameObject.Find("/backPack(Clone)/Panel/group/"+ putRedBoxNum.ToString()+"/light");
        
    }

    // Update is called once per frame
    void Update()
    {
        rightHand = GameObject.Find("hand_right");

		// Debug.Log("bPplace:" + bPplace);
		if(GameObject.Find("/backPack(Clone)") != null)
		{
			if (inBP)
			{
				transform.position = bPplace.transform.position + new Vector3(0,0,0.02f);
			}	
		}
		
		
		
		
    }

    void OnTriggerStay(Collider col)
    {
        // Debug.Log("collided");
        if (col.gameObject.tag == "right")
        {
            if (rightHand.transform.GetComponent<Raycasttest>().isHolding)
            {
				if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) && leftHandScript.putStuffInBP && inBP)
				{
					transform.parent = bPObj.transform.parent.transform;

					inBP = false;
				}
				transform.position = col.gameObject.transform.position;
				transform.rotation = col.gameObject.transform.rotation;
				transform.localScale = new Vector3(0.05f,0.05f,0.05f); 
            }
			else
			{	
				if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) && leftHandScript.putStuffInBP)
				{
					bPplace = GameObject.Find("/backPack(Clone)/Panel/group/"+ leftHandScript.backPackBox.ToString()+"/light");
					bPObj = GameObject.Find("/backPackObj");
					transform.parent = bPObj.transform;
					transform.localScale = new Vector3(1f,1f,1f);
					transform.position = bPplace.transform.position + new Vector3(0,0,0.02f);

					inBP = true;
				}
				// else
				// {
					// if(inBP)
					// {
						// transform.parent = bPObj.transform.parent.transform;
						// inBP = false;
					// }
					// transform.localScale = orignalSize;
				// }
				
			}

            //firstSet.transform.FindChild("protoroboghost").
        }
		


    }
}
