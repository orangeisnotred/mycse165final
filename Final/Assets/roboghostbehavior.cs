using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboghostbehavior : MonoBehaviour
{
    GameObject player;

    bool dead;
    bool waking = true;
    bool dying = false;
    public bool hit;
    bool hasSummoned;
    float dyingtime = 2;
    public float force;
    public int hp;
    public float speed;
    public bool isDropper;
    public GameObject cube;
    ParticleSystem sparks;

    

    public Vector3 hitPos;
    Vector3 diff;
    Vector3 risingDiff;
    Vector3 diff2;
    Vector3 diff3;

    public AudioClip summoningAudio;
    private AudioSource source;
    public AudioClip knifeAudio;
    public AudioClip hitAudio;
    public AudioClip trackingAudio;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        hasSummoned = false;
        hit = false;
        diff = player.transform.position - transform.position;
        risingDiff.x = transform.position.x;
        risingDiff.z = transform.position.z;
        risingDiff.y = player.transform.position.y;
        diff2 = risingDiff - transform.position;
        diff2 = Vector3.Normalize(diff2);
        sparks = transform.GetChild(2).GetComponent<ParticleSystem>();
        //InvokeRepeating("PlayTracking", 1.0f, 2.0f);

    }

    void PlayTracking()
    {
        if(!dead && !waking)
            source.PlayOneShot(trackingAudio, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {



        if (hit)
        {
            hp--;
            hit = false;
            if (hp > 0)
            {
                
               
                if (hp == 1)
                {
                    transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/V ghost", typeof(Material));
                    transform.GetChild(0).transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/V ghostHead", typeof(Material));
                    Color newColor = new Color(0.5490196f, 0.2509804f, 0.6431373f, 1);
                    transform.GetChild(1).transform.GetComponent<Light>().color = newColor;
                }

                if (hp == 2)
                {
                    transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/I ghost", typeof(Material));
                    transform.GetChild(0).transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/I ghostHead", typeof(Material));
                    Color newColor = new Color(0.459779f, 0.2509804f, 0.6431373f, 1);
                    transform.GetChild(1).transform.GetComponent<Light>().color = newColor;
                }

                if (hp == 3)
                {
                    transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/B ghost", typeof(Material));
                    transform.GetChild(0).transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/B ghostHead", typeof(Material));
                    Color newColor = new Color(0.2509804f, 0.62166f, 0.6431373f, 1);
                    transform.GetChild(1).transform.GetComponent<Light>().color = newColor;
                }

                if (hp == 4)
                {
                    transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/G ghost", typeof(Material));
                    transform.GetChild(0).transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/G ghostHead", typeof(Material));
                    Color newColor = new Color(0, 0.8235294f, 0.2039216f, 1);
                    transform.GetChild(1).transform.GetComponent<Light>().color = newColor;
                }

                if (hp == 5)
                {
                    transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/Y ghost", typeof(Material));
                    transform.GetChild(0).transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/Y ghostHead", typeof(Material));
                    Color newColor = new Color(0.7137255f, 0.8627451f, 0, 1);
                    transform.GetChild(1).transform.GetComponent<Light>().color = newColor;
                }

                if (hp == 6)
                {
                    transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/O ghost", typeof(Material));
                    transform.GetChild(0).transform.GetComponent<Renderer>().material = (Material)Resources.Load("ghost Materials/O ghostHead", typeof(Material));
                    Color newColor = new Color(0.8627451f, 0.5647059f, 0, 1);
                    transform.GetChild(1).transform.GetComponent<Light>().color = newColor;
                }

            }
            else
            {
                //hit = false;
                if (isDropper)
                {
                    Instantiate(cube, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform.root.transform);
                    isDropper = false;
                }

                dead = true;
                hit = true;
                diff = Vector3.Normalize(diff);

                diff.y = -.3f;
                //diff.x = diff.x ;
                //diff.z = diff.z ;
                // transform.GetComponen`t<Rigidbody>().AddForce(new Vector3(diff.x, .5f, diff.z), ForceMode.Impulse);

                transform.GetComponent<Rigidbody>().AddForceAtPosition(-diff / 3, hitPos, ForceMode.Force);
                dying = true;
                if (dying)
                {

                    sparks.Emit(5);
                    transform.GetComponent<Rigidbody>().detectCollisions = false;
                    dyingtime -= Time.deltaTime;

                    if (dyingtime <= 0)
                    {
                        Destroy(transform.gameObject);
                    }

                }
            }
        }
     
        if (!dead && !waking)
        {
            
            diff = player.transform.position - transform.position;
            transform.position = transform.position + (diff * Time.deltaTime * speed);
        }

        if(waking)
        {
           
            transform.position = transform.position + (diff2 * Time.deltaTime * speed);
     
            float dist = Vector3.Distance(risingDiff, transform.position);
            if(dist < 0.5)
            {
                waking = false;
            }

        }
        
        if (transform.position.y > 0 && !hasSummoned)
        {
            hasSummoned = true;
            source.PlayOneShot(summoningAudio, 1);

            
        }

        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "desk")
        {
            transform.GetComponent<Rigidbody>().detectCollisions = false;
        }

        if( col.gameObject.tag == "protoroboghost")
        {
            transform.GetComponent<Rigidbody>().detectCollisions = false;
            var dist = transform.position - col.gameObject.transform.position;
            transform.position = transform.position + (dist * Time.deltaTime);
        }

        if(col.gameObject.tag == "Player")
        {
            playerCollider.playerHp--;
            source.PlayOneShot(hitAudio, 1);
            //transform.GetComponent<Rigidbody>().detectCollisions = false;
            var dist = transform.position - col.gameObject.transform.position;
            transform.position = transform.position + (dist * 3);
            //p--;
        }

        if (col.gameObject.tag == "dagger")
        {
            if (hp == 1)
            {
                hit = true;
                source.PlayOneShot(knifeAudio, .8f);
            }

            //else
            //{
            //    var dist = transform.position - col.gameObject.transform.position;
            //    transform.position = transform.position + (dist * 3);
            //}
        }



    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "desk" || col.gameObject.tag == "protoroboghost" || col.gameObject.tag == "player")
        {
            transform.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }
}
