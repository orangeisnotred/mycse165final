using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftHandScript : MonoBehaviour
{
	GameObject backPack;
	GameObject rightHand;
	GameObject bP1;
	GameObject bP2;
	GameObject bP3;
	GameObject bP4;
	GameObject bP5;
	GameObject bP6;
	GameObject bP7;
	GameObject bP8;
	GameObject bP9;
	GameObject bP10;
	GameObject bP11;
	GameObject bP12;
	GameObject bP13;
	GameObject bP14;
	GameObject bP15;
	List<float> disArray;
	float minD;
	int index;
	GameObject backPackObj;
	
    // Start is called before the first frame update
    void Start()
    {
        backPackObj = GameObject.Find("/backPackObj");
		backPackObj.SetActive(true);
		
    }

    // Update is called once per frame
    void Update()
    {
		rightHand = GameObject.Find("/Player/OVRCameraRig/LocalAvatar/hand_right/handMode");
		
		
		
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
				
			
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
            {
                GameObject prefab = Resources.Load("backPack") as GameObject;
                backPack = Instantiate(prefab) as GameObject;
				foreach (Transform child in backPackObj.transform)
				{
					child.gameObject.SetActive(true);
				}
				
				
				bP1 = GameObject.Find("/backPack(Clone)/Panel/group/1/light");
				bP2 = GameObject.Find("/backPack(Clone)/Panel/group/2/light");
				bP3 = GameObject.Find("/backPack(Clone)/Panel/group/3/light");
				bP4 = GameObject.Find("/backPack(Clone)/Panel/group/4/light");
				bP5 = GameObject.Find("/backPack(Clone)/Panel/group/5/light");
				bP6 = GameObject.Find("/backPack(Clone)/Panel/group/6/light");
				bP7 = GameObject.Find("/backPack(Clone)/Panel/group/7/light");
				bP8 = GameObject.Find("/backPack(Clone)/Panel/group/8/light");
				bP9 = GameObject.Find("/backPack(Clone)/Panel/group/9/light");
				bP10 = GameObject.Find("/backPack(Clone)/Panel/group/10/light");
				bP11 = GameObject.Find("/backPack(Clone)/Panel/group/11/light");
				bP12 = GameObject.Find("/backPack(Clone)/Panel/group/12/light");
				bP13 = GameObject.Find("/backPack(Clone)/Panel/group/13/light");
				bP14 = GameObject.Find("/backPack(Clone)/Panel/group/14/light");
				bP15 = GameObject.Find("/backPack(Clone)/Panel/group/15/light");
                
            }
			backPack.transform.position = transform.position +  transform.TransformDirection(Vector3.forward) * 0.2f;// + new Vector3(0, 3, 0);
            backPack.transform.rotation = transform.rotation;
			
			
			disArray = new List<float>();
			disArray.Add(Vector3.Distance(bP1.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP2.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP3.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP4.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP5.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP6.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP7.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP8.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP9.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP10.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP11.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP12.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP13.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP14.transform.position,rightHand.transform.position));
			disArray.Add(Vector3.Distance(bP15.transform.position,rightHand.transform.position));
			disArray.Add(1000);
			for(int i = 0; i < disArray.Count - 1; i ++) {
				if(i == 0) {
					minD = disArray[i];
					index = 0;
				}
				if(disArray[i] < minD ) {
					minD  = disArray[i];
					index = i;
				}
			}
			
			
			if (minD<0.06f)
			{
				Debug.Log("index: "+index);
				if (index+1 == 1)
				{
					bP1.GetComponent<Light>().enabled = true;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 2)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = true;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;		

					
				}
				if (index+1 == 3)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = true;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 4)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = true;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 5)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = true;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 6)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = true;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 7)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = true;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 8)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = true;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 9)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = true;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 10)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = true;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 11)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = true;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 12)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = true;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 13)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = true;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 14)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = true;
					bP15.GetComponent<Light>().enabled = false;						
				}
				if (index+1 == 15)
				{
					bP1.GetComponent<Light>().enabled = false;
					bP2.GetComponent<Light>().enabled = false;
					bP3.GetComponent<Light>().enabled = false;
					bP4.GetComponent<Light>().enabled = false;
					bP5.GetComponent<Light>().enabled = false;
					bP6.GetComponent<Light>().enabled = false;
					bP7.GetComponent<Light>().enabled = false;
					bP8.GetComponent<Light>().enabled = false;
					bP9.GetComponent<Light>().enabled = false;
					bP10.GetComponent<Light>().enabled = false;
					bP11.GetComponent<Light>().enabled = false;
					bP12.GetComponent<Light>().enabled = false;
					bP13.GetComponent<Light>().enabled = false;
					bP14.GetComponent<Light>().enabled = false;
					bP15.GetComponent<Light>().enabled = true;						
				}
						
			}
			else
			{
				bP1.GetComponent<Light>().enabled = false;
				bP2.GetComponent<Light>().enabled = false;
				bP3.GetComponent<Light>().enabled = false;
				bP4.GetComponent<Light>().enabled = false;
				bP5.GetComponent<Light>().enabled = false;
				bP6.GetComponent<Light>().enabled = false;
				bP7.GetComponent<Light>().enabled = false;
				bP8.GetComponent<Light>().enabled = false;
				bP9.GetComponent<Light>().enabled = false;
				bP10.GetComponent<Light>().enabled = false;
				bP11.GetComponent<Light>().enabled = false;
				bP12.GetComponent<Light>().enabled = false;
				bP13.GetComponent<Light>().enabled = false;
				bP14.GetComponent<Light>().enabled = false;
				bP15.GetComponent<Light>().enabled = false;	
			}
			
			
        }
		if (!OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
			GameObject temp = GameObject.Find("/backPack(Clone)");
			if (temp!=null)
			{
				Destroy(backPack.gameObject);
				
				foreach (Transform child in backPackObj.transform)
				{
					child.gameObject.SetActive(false);
				}
				
				
			}
            
        }
		GameObject orgC = GameObject.Find("/backPackObj/orangeCube_small");
		orgC.transform.position = bP3.transform.position + new Vector3(0,0,0.02f);
		
		GameObject redC = GameObject.Find("/backPackObj/redCube_small");
		redC.transform.position = bP2.transform.position + new Vector3(0,0,0.02f);
		
		
		Debug.Log(Vector3.Distance(bP15.transform.position,rightHand.transform.position));
		// Debug.Log(bP1.transform.position);
		// Debug.Log(rightHand.transform.position);
    }
}
