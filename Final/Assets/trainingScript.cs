using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class trainingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstSet;
    public GameObject secondSet;
    public GameObject thirdSet;
    public GameObject fourthSet;
    GameObject player;
    GameObject tutorialMonitor;
    GameObject displayTextGO;
    GameObject image;

    Vector3 initPos = new Vector3(0,0,0);
    bool stored;
    bool fourPointFive = false;
    TextMeshPro displayText;
    public int step ;
    void Start()
    {
   
        tutorialMonitor = GameObject.Find("tutorialMonitor");
        displayTextGO = GameObject.Find("displayText");
        displayText = displayTextGO.GetComponent<TextMeshPro>();
        player = GameObject.Find("Player");
        image = GameObject.Find("controlImage");
        stored = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f && step == 0)
        {
            
            step++;
            foreach (Transform child in firstSet.transform)
            {
                child.gameObject.SetActive(true);

            }
        }
        if(step == 1)
        {

            displayText.text = "Move with Right Grip";
            if (!stored)
            {
                initPos.x = player.transform.position.x;
                initPos.y = player.transform.position.y;
                initPos.z = player.transform.position.z;
                stored = true;
            }
            else
            {
                float dist = Vector3.Distance(initPos, player.transform.position);
                Debug.Log(dist);
                if (dist > 5.0f)
                {

                    step++;
                }
            }
        }
        if (step == 2)
        {
            displayText.text = "Switch Modes with Left Trigger";
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f)
            {
                step++;
            }
        }
        if (step == 3)
        {
            displayText.text = "Open Bag with Left Grip";
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.Touch) > 0.0f)
            {
                step++;
            }
        }
        if (step == 4)
        {
            if(!fourPointFive)
                displayText.text = "Grab Cube with Right Trigger and Put in Bag";
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f)
            {
                fourPointFive = true;
                displayText.text = "Switch Back Modes to Continue";
               
            }
            if (fourPointFive)
            {
                if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f)
                {
                    step++;
                }
            }
        }
        if( step == 5)
        {
            displayText.text = "NOW KNIFE!";
            GameObject.Find("hand_right").transform.GetComponent<Raycasttest>().isUsingGun = false;
            foreach (Transform child in secondSet.transform)
            {
                child.gameObject.SetActive(true);

            }
            if (secondSet.transform.childCount == 0)
            {
                step++;
            }
        }
        if(step == 6)
        {
            image.SetActive(false);
            displayText.text = "While Aiming Directly With Knife, Use Left Grip to Charge at enemy";
            foreach (Transform child in thirdSet.transform)
            {
                child.gameObject.SetActive(true);

            }
            if (thirdSet.transform.childCount == 0)
            {
                step++;
            }
        }
        if(step == 7)
        {
            
            displayText.text = "WARNING: You can only KNIFE DAMAGE VIOLET enemies. \n Good Luck!";
            foreach (Transform child in fourthSet.transform)
            {
                child.gameObject.SetActive(true);

            }
            if (fourthSet.transform.childCount == 0)
            {
                step++;
            }
        }
        if(step == 8)
        {
            SceneManager.LoadScene("SampleScene");

        }
    }
}
