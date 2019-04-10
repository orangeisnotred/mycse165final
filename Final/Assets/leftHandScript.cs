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

    GameObject lastRobo;

    Material highlight;
    Material original;
	List<float> disArray;
	float minD;
	int index;
    bool canSwitch;
    bool battleMode;
	static public bool putStuffInBP = false;
    public float angle = 0.0f;
	
	static public string backPackBox;
   
    GameObject backPackObj;

    // GameObject firstSetEn;
    // firstSetLeftNum = firstSetEn.transform.childCount;
    // GameObject firstLast;
    // Vector3 firstLastPosition;
    GameObject dagger;
	
	GameObject theRedCube;
	GameObject firstLast;
	Vector3 firstLastPosition;

    GameObject theIndigCube;
    GameObject secondLast;
    Vector3 secondLastPosition;
    bool firstSetLastKilled;
    bool secondSetLastKilled;

  
   


    // Start is called before the first frame update
    void Start()
    {

        backPackObj = GameObject.Find("/backPackObj");
        dagger = GameObject.Find("dagger");
        highlight = (Material)Resources.Load("highLight", typeof(Material));
        backPackObj.SetActive(true);
        canSwitch = true;
        battleMode = true;
       
    }

    // Update is called once per frame
    void Update()
    {
		rightHand = GameObject.Find("/Player/OVRCameraRig/LocalAvatar/hand_right/handMode");

        Vector3 dir;
        RaycastHit hit = new RaycastHit();
        dir.x = 1;
        dir.y = 0;
        dir.z = 0;
        dir = Quaternion.AngleAxis(-90, Vector3.forward) * dir;

        Debug.DrawRay(transform.position, transform.TransformDirection(dir) * 10, Color.yellow);
        if (lastRobo)
        {
         
                lastRobo.transform.GetComponent<Renderer>().material = original;
            
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir) * 500, out hit, 5000))
        {
            if (lastRobo)
            {
                if(hit.transform.gameObject != lastRobo)
                {
                    lastRobo.transform.GetComponent<Renderer>().material = original;
                }
            }
            if (hit.transform.tag == "roboGhost" )
            {
                roboghostbehavior script = hit.transform.GetComponent<roboghostbehavior>();
                if (script.hp == 1)
                {
                    original = hit.transform.GetComponent<Renderer>().material;
                    hit.transform.GetComponent<Renderer>().material = highlight;
                    lastRobo = hit.transform.gameObject;
                    if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) && battleMode)
                    {
                        Debug.Log("hittingghost");

                        //Raycasttest.stop = true;


                        if (script.hp == 1)
                        {
                            Vector3 dist = hit.transform.position - transform.root.transform.position;
                            dist = Vector3.Normalize(dist);
                            Vector3 newPos = transform.root.transform.position + (dist * Time.deltaTime * 15);
                            newPos.y = transform.root.position.y;
                            transform.root.transform.position = newPos;

                        }
                    }
                }
            }
            else if (lastRobo)
            {
               
                    lastRobo.transform.GetComponent<Renderer>().material = original;
                
            }

        }
        else if (lastRobo)
        {
           
                lastRobo.transform.GetComponent<Renderer>().material = original;
            
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) && !battleMode)
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
			// disArray.Add(1000);
			for(int i = 0; i <= disArray.Count - 1; i ++) {
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
					backPackBox = "1";		
					putStuffInBP = true;
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
					backPackBox = "2";		
					putStuffInBP = true;

					
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
					backPackBox = "3";		
					putStuffInBP = true;
					
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
					backPackBox = "4";		
					putStuffInBP = true;
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
					backPackBox = "5";	
					putStuffInBP = true;					
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
					backPackBox = "6";	
					putStuffInBP = true;	
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
					backPackBox = "7";
					putStuffInBP = true;
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
					backPackBox = "8";		
					putStuffInBP = true;
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
					backPackBox = "9";	
					putStuffInBP = true;					
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
					backPackBox = "10";	
					putStuffInBP = true;
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
					backPackBox = "11";		
					putStuffInBP = true;
					
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
					backPackBox = "12";		
					putStuffInBP = true;
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
					backPackBox = "13";	
					putStuffInBP = true;					
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
					backPackBox = "14";
					putStuffInBP = true;
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
					backPackBox = "15";		
					putStuffInBP = true;
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
				backPackBox = "100";	
				putStuffInBP = false;
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
        /////////////////SWITCH BETWEEN MODES////////////////////
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f && canSwitch)
        {
            canSwitch = false;

           if( GameObject.Find("hand_right").transform.GetComponent<Raycasttest>().isUsingGun)
            {
                battleMode = false;
                dagger.SetActive(false);
                GameObject.Find("hand_right").transform.GetComponent<Raycasttest>().isUsingGun = false;
				GameObject.Find("hand_right").transform.GetComponent<BoxCollider>().center =new Vector3(0,0,0);
				GameObject.Find("hand_right").transform.GetComponent<BoxCollider>().size =new Vector3(0.05f,0.05f,0.13f);
                
            }
            else
            {
                battleMode = true;
                GameObject.Find("hand_right").transform.GetComponent<Raycasttest>().isUsingGun = true ;
                dagger.SetActive(true);
                GameObject.Find("hand_right").transform.GetComponent<BoxCollider>().center =new Vector3(0,0,5);
				GameObject.Find("hand_right").transform.GetComponent<BoxCollider>().size =new Vector3(0.05f,0.05f,10.05f);
            }
        }
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch) == 0.0f && !canSwitch)
        {
            canSwitch = true;
        }

		

		
		//GameObject firstSetEn = GameObject.Find("/firstSet");
		//int firstSetLeftNum = firstSetEn.transform.childCount;

		/////////////To drop from enemy///////////
		//if (firstSetLeftNum == 1)
		//{
		//	firstLast = firstSetEn.gameObject.transform.GetChild(0).gameObject;
		//	firstLastPosition = firstLast.transform.position;
		//	//Debug.Log(firstSetLeftNum);
		//	firstSetLastKilled = false;
		//}
		//else if (firstSetLeftNum == 0)
		//{
		//	if (!firstSetLastKilled)
		//	{
		//		GameObject obj = Resources.Load("theRedCube") as GameObject;
		//		theRedCube = Instantiate(obj) as GameObject;
		//		firstLastPosition = new Vector3(83.74939f,1.6f,24.00222f);
		//		theRedCube.transform.position = firstLastPosition;
		//	}
			
		//	firstSetLastKilled = true;
		//}



  //      GameObject secondSetEn = GameObject.Find("/secondSet");
  //      int secondSetLeftNum = firstSetEn.transform.childCount;

  //      ///////////To drop from enemy///////////
  //      if (secondSetLeftNum == 1)
  //      {
  //          secondLast = firstSetEn.gameObject.transform.GetChild(0).gameObject;
  //          secondLastPosition = secondLast.transform.position;
  //          //Debug.Log(firstSetLeftNum);
  //          secondSetLastKilled = false;
  //      }
  //      else if (secondSetLeftNum == 0)
  //      {
  //          if (!secondSetLastKilled)
  //          {
  //              GameObject obj = Resources.Load("theRedCube") as GameObject;
  //              theRedCube = Instantiate(obj) as GameObject;
  //              firstLastPosition = new Vector3(83.74939f, 1.6f, 24.00222f);
  //              theRedCube.transform.position = firstLastPosition;
  //          }

  //          secondSetLastKilled = true;
  //      }




        // if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        // {
        // // GameObject firstSet = GameObject.Find("/firstSet");
        // // if(firstSetLeftNum==0)
        // // {

        // // }

        // GameObject orgC = GameObject.Find("/backPackObj/orangeCube_small");   /////////////////////////////////Commented out because error
        // orgC.transform.position = bP3.transform.position + new Vector3(0,0,0.02f);

        // GameObject redC = GameObject.Find("/backPackObj/redCube_small");
        // redC.transform.position = bP2.transform.position + new Vector3(0,0,0.02f);
        // }

        // Debug.Log(Vector3.Distance(bP15.transform.position,rightHand.transform.position));
        // Debug.Log(bP1.transform.position);
        // Debug.Log(rightHand.transform.position);

    }
}
