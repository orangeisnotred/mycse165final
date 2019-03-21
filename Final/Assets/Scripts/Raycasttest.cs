using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    GameObject gun;
    GameObject inputText;
    GameObject inputScreen;
    GameObject inputLight;
    Material redScreen;
    Material greenScreen;
    Material whiteScreen;

    Transform tempformer;
    Renderer rend = null;
    Color original;
    bool desklock; //locks abiliy to spawn desk
    bool objectlock = false; //object is skewed
    bool teleportLock = false;
    public static bool continuousMotion = true;
    public static bool stop = false;
    public bool training;
    bool stored = false;
    bool superman = false;
    bool teleArrow = true;
    bool canVibrate = true;
    bool blueTime = false;
    bool canShoot = true;
    bool complete = false;
    public bool isHolding;
    public bool isUsingGun = true;
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
    public AudioClip afterLaserAudio;
    private AudioSource source;

    Gradient gradient;
    Gradient gradient2;

    ParticleSystem gunSparks;
    GameObject gunSprks_GO;
    TextMeshPro textScript;
    TextMeshPro infoScript;



    int colorCounter = 0;

    void Start()
    {
        source = GetComponent<AudioSource>();
        laserLine = GetComponent<LineRenderer>();
       
        laserpointer = (Material)Resources.Load("laserPointer", typeof(Material));
        laserLine.material = laserpointer;
        laserMat = (Material)Resources.Load("laser", typeof(Material));

        if (!training)
        {
            inputText = GameObject.Find("inputMonitor").transform.GetChild(2).gameObject;
            textScript = inputText.GetComponent<TextMeshPro>();
            inputText = GameObject.Find("inputMonitor").transform.GetChild(4).gameObject;
            infoScript = inputText.GetComponent<TextMeshPro>();
            inputScreen = GameObject.Find("inputMonitor").transform.GetChild(0).gameObject;
            inputLight = GameObject.Find("inputMonitor").transform.GetChild(5).gameObject;
        }
        // laserLine.colorGradient = gradient;




        transform.forward = GameObject.Find("CenterEyeAnchor").transform.forward;

        gunSparks = GameObject.Find("Gunsparks").GetComponent<ParticleSystem>();
        gunSprks_GO = GameObject.Find("Gunsparks");
        gun = GameObject.Find("SciFiGun_Diffuse");
        isHolding = false;
    }

    
    // Update is called once per frame
    void Update()
    {

        RaycastHit hit = new RaycastHit();
        ////////////BATTLE MODE////////////
        if (isUsingGun)
        {
            isHolding = false;
            laserLine.enabled = true;
            gun.SetActive(true);
            transform.GetComponent<BoxCollider>().enabled = false;

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
                    //gunSparks.Burst(2.0f, 100);
                    gunSparks.Emit(5);

                    // gunSparks.Play();
                }
                else
                {

                    lasertime = .25f;
                    blueTime = false;
                    //gunSparks.Pause();
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
                source.PlayOneShot(laser, .7f);
                source.PlayOneShot(afterLaserAudio, .1f);
                OVRInput.SetControllerVibration(0.5f, 1, OVRInput.Controller.RTouch);
                canVibrate = false;

            }
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) == 0.0f && !canVibrate)
            {
                canVibrate = true;
            }
        }

        else//////////////////////grabbing/////////////
        {
            laserLine.enabled = false;
            gun.SetActive(false);
            transform.GetComponent<BoxCollider>().enabled = true;
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f)
            {
                isHolding = true;

            }

            else
            {
                isHolding = false;
            }
        }

            //destination.SetActive(false);
            //arrowTele.SetActive(false);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 10, out hit, 5000))
            {
            

           

                if (hit.transform.tag == "roboGhost")
                {
                    if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f && canShoot)
                    {

                        canShoot = false;
                        roboghostbehavior script = hit.transform.GetComponent<roboghostbehavior>();
                        script.hit = true;
                        script.hitPos = hit.point;
                    }

                    if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) == 0.0f && !canShoot)
                    {

                        canShoot = true;
            
                    }


                }
            ///////////SYMBOLIC INPUT//////////
            if (hit.transform.tag == "letter" && !complete)
            {
              
                
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0.0f && canShoot)
                {

                    canShoot = false;
                   
                    textScript.text += hit.collider.gameObject.name;
                    if (textScript.text.Length == 7)
                    {
                        if (textScript.text == "SPECTRA")
                        {
                            infoScript.text = "CORRECT!";
                            inputScreen.transform.GetComponent<Renderer>().material = (Material)Resources.Load("greenlight", typeof(Material));
                            inputLight.GetComponent<Light>().color = Color.green;
                            complete = true;


                        }
                        else
                        {
                            textScript.text = "";
                            infoScript.text = "INCORRECT!";
                           
                            inputScreen.transform.GetComponent<Renderer>().material = (Material)Resources.Load("laserPointer", typeof(Material));
                            inputLight.GetComponent<Light>().color = Color.red;
                        }


                    }
                    else
                    {
                        inputScreen.transform.GetComponent<Renderer>().material = (Material)Resources.Load("indigoCube", typeof(Material));
                        inputLight.GetComponent<Light>().color = Color.white;
                    }

                }

                if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) == 0.0f && !canShoot)
                {

                    canShoot = true;

                }
                  
               
            }
                



           
            }
       
       



        

      

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) == 0.0f && !continuousMotion)
        {
            teleportLock = false;
           
        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) == 0.0f || stop)
        {
       
            stored = false;
            stop = false;
        }
        //////////////////////////////              WALKING            /////////////////////////////
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0.0f && continuousMotion && !stop)
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
            
            


            Quaternion finRot = (Quaternion.Slerp(transform.root.transform.rotation, transform.root.transform.rotation * diff, 0.007f));
            transform.root.transform.rotation = finRot;/////////////////////ROTATION DISABLE
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

            pos = diff2 * (pos * 20); //////////UNNORMALIZED MOVEMENT
            //pos = diff2 * (pos); //////////Normalized
            pos2 = transform.root.transform.position;
           // pos = Vector3.Normalize(pos);
            pos2 = pos2 + (pos * Time.deltaTime); 
            if(!superman)
            pos2.y = transform.root.transform.position.y;
            transform.root.transform.position = pos2;

           




        }

        if (false)
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


       

    }



}
