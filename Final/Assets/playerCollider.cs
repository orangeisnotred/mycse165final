using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class playerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameOver = false;
    public static int playerHp = 20;
    int currHp = 20;
    bool FadingOut = false;
    bool Dying = false;
    TextMeshPro deathText;

    float fadingTime = 5.0f;
    float dyingTime = 5.0f;
    GameObject overlay;
    GameObject deathScreen;
    void Start()
    {
        overlay = GameObject.Find("Overlay");
        overlay.transform.GetChild(0).transform.GetComponent<Image>().CrossFadeAlpha(0, 5.0f, false);
        overlay.transform.GetChild(1).transform.GetComponent<Image>().CrossFadeAlpha(0, 5.0f, false);
        deathScreen = overlay.transform.GetChild(2).gameObject;
        deathText = overlay.transform.GetChild(3).gameObject.transform.GetComponent<TextMeshPro>();
        overlay.transform.GetChild(1).transform.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currHp > playerHp && !Dying)
        {
            currHp = playerHp;
            overlay.transform.GetChild(1).transform.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            overlay.transform.GetChild(0).transform.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            overlay.transform.GetChild(1).transform.GetComponent<Image>().fillAmount += .05f;
            FadingOut = true;

        }
        if (FadingOut && !Dying)
        {
            
            if (fadingTime > 3.0f)
            {
                ;
            }
            if (fadingTime < 3.0f)
            {

                overlay.transform.GetChild(0).transform.GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
                overlay.transform.GetChild(1).transform.GetComponent<Image>().CrossFadeAlpha(0, 2.0f, false);
                FadingOut = false;
                fadingTime = 5.0f;
            }
            fadingTime -= Time.deltaTime;

        }
        
        if(playerHp <= 0)//GAMEOVER
        {
            Dying = true;
            if (Dying)
            {

        
                if (dyingTime > 1.0f)
                {


                    deathScreen.transform.GetComponent<Image>().fillAmount += .2f;
                    deathScreen.transform.localScale += new Vector3(0.2F, 0.2F, 0.2F);
                    Vector3 zval = deathScreen.transform.localScale;
                    zval.z -= 50;
                    deathScreen.transform.localScale = zval;
                    Debug.Log(dyingTime);
                   
                }

                if(dyingTime < 3.0f)
                {
                    deathText.text = "GAME OVER";
                }
                if (dyingTime <= 1.0f)
                {
                    Debug.Log("Not Resetting");
             
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    playerHp = 10;
                    deathScreen.transform.GetComponent<Image>().fillAmount = 0;
                    currHp = 10;
                }
                dyingTime -= Time.deltaTime;

            }
            gameOver = true;
           
            //
           
        }

    }

    void OnTriggerEnter(Collider col)
    {

       
        
        if (col.gameObject.tag == "wall")
        {
            Debug.Log("is coliding");
            float y = transform.position.y;
            var dist = transform.position - col.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            dist.y = 0;
            dist = Vector3.Normalize(dist);
            Raycasttest.stop = true;
            transform.position = transform.position + (dist);
            
        }

       




    }
}
