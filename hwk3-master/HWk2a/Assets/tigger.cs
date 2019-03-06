using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tigger : MonoBehaviour
{
	GameObject light;
	static int redOne;
	static int orangeOne;
	static int yellowOne;
	static int greenOne;
	static int blueOne;
	static int indigoOne;
	static int violetOne;

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Enter");
        if (other.gameObject.tag == "redOne")
        {
			// Debug.Log("redOne");
			redOne = 1;
        }
		
		if (other.gameObject.tag == "orangeOne")
        {
			// Debug.Log("orangeOne");
			orangeOne = 1;
        }
		
		if (other.gameObject.tag == "yellowOne")
        {
			Debug.Log("yellowOne");
			yellowOne = 1;
        }
		
		if (other.gameObject.tag == "greenOne")
        {
			Debug.Log("greenOne");
			greenOne = 1;
        }
		
		if (other.gameObject.tag == "blueOne")
        {
			Debug.Log("blueOne");
			blueOne = 1;
        }
		
		if (other.gameObject.tag == "indigoOne")
        {
			Debug.Log("indigoOne");
			indigoOne = 1;
        }
		
		if (other.gameObject.tag == "violetOne")
        {
			Debug.Log("violetOne");
			violetOne = 1;
        }

        
    }


    // Start is called before the first frame update
    void Start()
    {
		redOne = 0;
		orangeOne = 0;
		yellowOne = 0;
		greenOne = 0;
		blueOne = 0;
		indigoOne = 0;
		violetOne = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if((redOne + tiggerBox.redHolder) == 2)
		{
			
			light = GameObject.Find("/redLight/light");
			light.GetComponent<Light>().enabled = true;
		}
		
		if((orangeOne + tiggerBox.orangeHolder) == 2)
		{
			
			light = GameObject.Find("/orangeLight/light");
			light.GetComponent<Light>().enabled = true;
		}
		
		if((yellowOne + tiggerBox.yellowHolder) == 2)
		{
			
			light = GameObject.Find("/yellowLight/light");
			light.GetComponent<Light>().enabled = true;
		}
		
		if((greenOne + tiggerBox.greenHolder) == 2)
		{
			
			light = GameObject.Find("/greenLight/light");
			light.GetComponent<Light>().enabled = true;
		}
		
		if((blueOne + tiggerBox.blueHolder) == 2)
		{
			
			light = GameObject.Find("/blueLight/light");
			light.GetComponent<Light>().enabled = true;
		}
		
		if((indigoOne + tiggerBox.indigoHolder) == 2)
		{
			
			light = GameObject.Find("/indigoLight/light");
			light.GetComponent<Light>().enabled = true;
		}
		
		if((violetOne + tiggerBox.violetHolder) == 2)
		{
			
			light = GameObject.Find("/violetLight/light");
			light.GetComponent<Light>().enabled = true;
		}
    }
}
