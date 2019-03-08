﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Raycasttest : MonoBehaviour {
    private LineRenderer laserLine;
    public GameObject tBG; //teleport Background
    public GameObject wBG; //walk Background
    public GameObject sBG; //teleport Background
    public GameObject sIMG; //walk Background
    GameObject chairPre;
    GameObject deskPre;
    GameObject desk;
    GameObject chair;
    GameObject destination;
    GameObject arrowTelePre;
    GameObject arrowTele;
    GameObject destinationPre;
    GameObject currGameObject = null; //used for highlighting
    
    Transform tempformer;
    Renderer rend = null;
    Color original;
    bool desklock; //locks abiliy to spawn desk
    bool objectlock = false; //object is skewed
    bool teleportLock = false;
    bool continuousMotion = false;
    bool stored = false;
    bool superman = false;
    bool teleArrow = true;
    bool canVibrate = true;
    bool blueTime = false;
    float heldDownTime;
    public float lasertime = .25f;
    float dist;
    private List<Color> originalColors = new List<Color>();
    Light lastHighlight;

    Material laserpointer;
    Material laserMat;

    public int maxSize = 30;

    public float delay = 0.25f;


    Vector3 lastPosition;
    Vector3 initialPos;
    Quaternion initialRot;
    Quaternion newRot;
    Quaternion newRot2;
    private float timeCount = 0.0f;

    public AudioClip laser;
    private AudioSource source;

    Gradient gradient;
    Gradient gradient2;

    int colorCounter = 0;

    void Start()
    {
        source = GetComponent<AudioSource>();
        laserLine = GetComponent<LineRenderer>();
       
        laserpointer = (Material)Resources.Load("laserPointer", typeof(Material));
        laserLine.material = laserpointer;
        laserMat = (Material)Resources.Load("laser", typeof(Material));

        

       // laserLine.colorGradient = gradient;
       
        chairPre = Resources.Load("chair") as GameObject;
        deskPre = Resources.Load("desk2") as GameObject;
        
       
         transform.forward = GameObject.Find("CenterEyeAnchor").transform.forward;
    }

    
    // Update is called once per frame
    void Update()
    {
       



        laserLine.enabled = true;
        RaycastHit hit = new RaycastHit();

        desklock = false;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.yellow);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);

        if (blueTime)
        {
            lasertime -= Time.deltaTime;
            if (lasertime >= 0)
            {
                laserLine.SetWidth(0.02f, 0.02f);

                laserLine.material = laserMat;
               
            }
            else
            {
                lasertime = .25f;
                blueTime = false;
            }
        }
        else
        {
            laserLine.SetWidth(0.005f, 0.005f);
            laserLine.material = laserpointer;
        }
       
        
        ///////////////SHOOTING//////////////////
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f && canVibrate)
        {
            blueTime = true;
            source.PlayOneShot(laser, .5f);
            OVRInput.SetControllerVibration(0, 1, OVRInput.Controller.RTouch);
            canVibrate = false;
            
        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) == 0.0f && !canVibrate)
        {
            canVibrate = true;
        }


            //destination.SetActive(false);
            //arrowTele.SetActive(false);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 10, out hit, 5000))
        {
            if (currGameObject != null && currGameObject != hit.transform.gameObject && lastHighlight != null)
            {
                lastHighlight.enabled = false;
            }
            currGameObject = hit.transform.gameObject;
            if (hit.transform.tag == "desk")
            {

                lastHighlight = hit.collider.gameObject.GetComponent<Light>();
                hit.collider.gameObject.GetComponent<Light>().enabled = true;

                desklock = true;
                if (OVRInput.Get(OVRInput.RawButton.A))
                {

                    if (!objectlock)
                    {
                        dist = Vector3.Distance(hit.transform.position, transform.position);
                        objectlock = true;
                    }

                    hit.transform.position = (transform.position + (transform.TransformDirection(Vector3.forward).normalized * dist));



                }
                if (OVRInput.GetUp(OVRInput.RawButton.A))
                {
                    objectlock = false;

                }

            }

            if (hit.transform.tag == "chair")
            {
                //foreach (Renderer r in hit.collider.gameObject.GetComponentsInChildren<Renderer>())
                //{
                //    originalColors.Add(r.material.color);
                //    r.material.color = Color.red;

                //}  
                lastHighlight = hit.collider.gameObject.GetComponent<Light>();
                hit.collider.gameObject.GetComponent<Light>().enabled = true;

                desklock = true;
                if (OVRInput.Get(OVRInput.RawButton.A))
                {

                    if (!objectlock)
                    {
                        dist = Vector3.Distance(hit.transform.position, transform.position);
                        objectlock = true;
                    }

                    hit.transform.position = (transform.position + (transform.TransformDirection(Vector3.forward).normalized * dist));



                }
                if (OVRInput.GetUp(OVRInput.RawButton.A))
                {
                    objectlock = false;

                }

            }

            if (hit.transform.tag == "roboGhost")
            {
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f)
                {


                    roboghostbehavior script = hit.transform.GetComponent<roboghostbehavior>();
                    script.hit = true;
                    script.hitPos = hit.point;
                }
            }

            //if (hit.transform.tag == "ground") //////TELEPORTATION////
            //{
            //    if (teleArrow)
            //    {
            //        arrowTele.SetActive(true);
            //        arrowTele.transform.position = hit.point;



                //        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight))
                //        {
                //            var angles = arrowTele.transform.rotation.eulerAngles;
                //            angles.y += Time.deltaTime * 100;
                //            arrowTele.transform.rotation = Quaternion.Euler(angles);

                //        }

                //        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft))
                //        {
                //            var angles = arrowTele.transform.rotation.eulerAngles;
                //            angles.y -= Time.deltaTime * 100;
                //            arrowTele.transform.rotation = Quaternion.Euler(angles);

                //        }


                //        Debug.Log("arrow loc " + arrowTele.transform.position);
                //        Debug.Log("point loc " + hit.point);



                //    }
                //    else
                //    {
                //       // destination.SetActive(true);
                //        //destination.transform.position = hit.point;
                //    }

                //    //destination.SetActive(true);
                //    //destination.transform.position = hit.point;
                //    float tempY = transform.root.transform.position.y;

                //    if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0.0f && !teleportLock)
                //    {
                //        teleportLock = true;
                //        Vector3 pos = hit.point;
                //        pos.y = tempY;
                //        transform.root.transform.position = pos;
                //        if (teleArrow)
                //        {
                //           // var angles2 = arrowTele.transform.rotation.eulerAngles;
                //           // angles2.y += 180;
                //           // arrowTele.transform.rotation = Quaternion.Euler(angles2);
                //            transform.root.transform.rotation = arrowTele.transform.rotation;
                //        }

                //    }







                //}
        }
        else
        {
            if (lastHighlight != null)
                lastHighlight.enabled = false;

        }
        ////DESK////
        if (OVRInput.GetDown(OVRInput.RawButton.A) && !desklock)
        {
            
            heldDownTime = Time.deltaTime;
            desk = Instantiate(deskPre) as GameObject;
           

        }

        if (OVRInput.Get(OVRInput.RawButton.A) && !desklock)
        {
            desk.transform.position = (transform.position + (transform.TransformDirection(Vector3.forward).normalized * 2));
           
       
            desk.transform.rotation = transform.rotation;
            desk.transform.Rotate(-90, 90, 0);
        }



        //if (OVRInput.GetUp(OVRInput.RawButton.A)){
        //    heldDownTime = Time.deltaTime;
        //    desk = Instantiate(deskPre) as GameObject;

        //    desk.transform.position = (transform.position + (transform.TransformDirection(Vector3.forward).normalized * 2));
        //}


        /////CHAIR///////
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            heldDownTime = Time.deltaTime;
            chair = Instantiate(chairPre) as GameObject;


        }

        if (OVRInput.Get(OVRInput.RawButton.B))
        {
            chair.transform.position = (transform.position + (transform.TransformDirection(Vector3.forward).normalized * 2));


            chair.transform.rotation = transform.rotation;
            chair.transform.Rotate(-90, 90, 0);
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) == 0.0f && !continuousMotion)
        {
            teleportLock = false;
           
        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) == 0.0f && continuousMotion)
        {
       
            stored = false;
        }
        //////////////////////////////              WALKING            /////////////////////////////
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0.0f && continuousMotion)
        {
            if (!stored)
            {
                initialPos.x = transform.localPosition.x;
                initialPos.z = transform.localPosition.z;
                if (superman)
                {
                    initialPos.y = transform.localPosition.y;
                }
                initialRot.Set(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
                stored = true;
            }
           
            newRot.Set(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
            
            Quaternion diff = newRot * Quaternion.Inverse(initialRot);

   
            //{
            //    diff = Quaternion.AngleAxis(170, Vector3.up);
            
            


            Quaternion finRot = (Quaternion.Slerp(transform.root.transform.rotation, transform.root.transform.rotation * diff, 0.01f));
            transform.root.transform.rotation = finRot;
            if (!superman)
            {
                transform.root.transform.rotation = Quaternion.Euler(new Vector3(0f, transform.root.transform.rotation.eulerAngles.y, 0f));
            }
            //timeCount = timeCount + Time.deltaTime;





            //////////////////POSITION///////////////////
            Vector3 pos;
            Vector3 pos2;
            Vector3 pos3 = transform.localPosition;
            Quaternion diff2 = transform.rotation * Quaternion.Inverse(transform.localRotation);

               
            pos = transform.localPosition - initialPos;
            //pos = Vector3.Normalize(pos);


























            // pos = transform.rotation * (pos * 10);

            pos = diff2 * (pos * 50);
            
            pos2 = transform.root.transform.position;
            
            pos2 = pos2 + (pos * Time.deltaTime); 
            if(!superman)
            pos2.y = transform.root.transform.position.y;
            transform.root.transform.position = pos2;

           




        }

        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {

            if (!continuousMotion)
            {
                teleportLock = true;
                continuousMotion = true;
                tBG.SetActive(false);
                wBG.SetActive(true);

            }
            else
            {
                teleportLock = false;
                continuousMotion = false;
                tBG.SetActive(true);
                wBG.SetActive(false);
                superman = false;
                sBG.SetActive(false);
                sIMG.SetActive(false);
            }
            
        }


        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            if (!superman && continuousMotion)
            {
                superman = true;
                sBG.SetActive(true);
                sIMG.SetActive(true);
                wBG.SetActive(false);

            }
            else if(superman && continuousMotion)
            {
                superman = false;
                sBG.SetActive(false);
                sIMG.SetActive(false);
                wBG.SetActive(true);
            }
            
        }

    }



}
