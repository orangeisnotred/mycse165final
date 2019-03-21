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
	public AudioClip bingoClip;
	private AudioSource bingoSource;
	
	
	bool initRed = false;
	bool initOrange = false;
	bool initYellow = false;
	bool initGreen = false;
	bool initBlue = false;
	bool initIndigo = false;
	bool initViolet = false;

	

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
		GetComponent<AudioSource>().mute = true;
		bingoSource = GetComponent<AudioSource>();
		// GetComponent<AudioSource>().mute = false;
		
		
    }

    // Update is called once per frame
    void Update()
    {

        if((redOne + tiggerBox.redHolder) == 2)
		{
			if(!initRed)
			{
				GetComponent<AudioSource>().mute = false;
				bingoSource.Play();
				GameObject CUBE = GameObject.Find("/theRedCube");
				CUBE.GetComponent<boxscriptV2>().enabled = false;
				GameObject CUBEPUT = GameObject.Find("/tableTrigger/putCard/R/Cube");
				CUBE.transform.position = CUBEPUT.transform.position + new Vector3(0,0.1f,0);
				CUBE.transform.rotation = Quaternion.Euler(0, 30, 45);		
				CUBE.transform.localScale = new Vector3(0.15f,0.15f,0.15f); 
				light = GameObject.Find("/tablePuzzleHint/redLight/light");
				light.GetComponent<Light>().enabled = true;
			}
			initRed = true;
		}
		// Debug.Log('redONe: '+redOne);
		// Debug.Log('redHolder: '+tiggerBox.redHolder);
		// Debug.Log('initRed: '+initRed);

		
		
		if((orangeOne + tiggerBox.orangeHolder) == 2)
		{
			if(!initOrange)
			{
				GetComponent<AudioSource>().mute = false;
				bingoSource.Play();
				GameObject CUBE = GameObject.Find("/theOrangeCube(Clone)");
				CUBE.GetComponent<boxscriptV2>().enabled = false;
				GameObject CUBEPUT = GameObject.Find("/tableTrigger/putCard/O/Cube");
				CUBE.transform.position = CUBEPUT.transform.position + new Vector3(0,0.1f,0);
				CUBE.transform.rotation = Quaternion.Euler(0, 30, 45);		
				CUBE.transform.localScale = new Vector3(0.15f,0.15f,0.15f); 
				light = GameObject.Find("/tablePuzzleHint/orangeLight/light");
				light.GetComponent<Light>().enabled = true;
			}
			initOrange = true;
		}

		
		if((yellowOne + tiggerBox.yellowHolder) == 2)
		{
			if(!initYellow)
			{
				GetComponent<AudioSource>().mute = false;
				bingoSource.Play();
				GameObject CUBE = GameObject.Find("/theYellowCube(Clone)");
				CUBE.GetComponent<boxscriptV2>().enabled = false;
				GameObject CUBEPUT = GameObject.Find("/tableTrigger/putCard/Y/Cube");
				CUBE.transform.position = CUBEPUT.transform.position + new Vector3(0,0.1f,0);
				CUBE.transform.rotation = Quaternion.Euler(0, 30, 45);		
				CUBE.transform.localScale = new Vector3(0.15f,0.15f,0.15f); 
				light = GameObject.Find("/tablePuzzleHint/yellowLight/light");
				light.GetComponent<Light>().enabled = true;
			}
			initYellow = true;

		}
		
		if((greenOne + tiggerBox.greenHolder) == 2)
		{
			if(!initGreen)
			{
				GetComponent<AudioSource>().mute = false;
				bingoSource.Play();
				GameObject CUBE = GameObject.Find("/theGreenCube(Clone)");
				CUBE.GetComponent<boxscriptV2>().enabled = false;
				GameObject CUBEPUT = GameObject.Find("/tableTrigger/putCard/G/Cube");
				CUBE.transform.position = CUBEPUT.transform.position + new Vector3(0,0.1f,0);
				CUBE.transform.rotation = Quaternion.Euler(0, 30, 45);		
				CUBE.transform.localScale = new Vector3(0.15f,0.15f,0.15f); 
				light = GameObject.Find("/tablePuzzleHint/greenLight/light");
				light.GetComponent<Light>().enabled = true;
			}
			initGreen = true;
		}
		
		if((blueOne + tiggerBox.blueHolder) == 2)
		{
			if(!initBlue)
			{
				GetComponent<AudioSource>().mute = false;
				bingoSource.Play();
				GameObject CUBE = GameObject.Find("/theBlueCube(Clone)");
				CUBE.GetComponent<boxscriptV2>().enabled = false;
				GameObject CUBEPUT = GameObject.Find("/tableTrigger/putCard/B/Cube");
				CUBE.transform.position = CUBEPUT.transform.position + new Vector3(0,0.1f,0);
				CUBE.transform.rotation = Quaternion.Euler(0, 30, 45);		
				CUBE.transform.localScale = new Vector3(0.15f,0.15f,0.15f); 
				light = GameObject.Find("/tablePuzzleHint/blueLight/light");
				light.GetComponent<Light>().enabled = true;
			}
			initBlue = true;
		}
		
		if((indigoOne + tiggerBox.indigoHolder) == 2)
		{
			if(!initIndigo)
			{
				GetComponent<AudioSource>().mute = false;
				bingoSource.Play();
				GameObject CUBE = GameObject.Find("/theIndigoCube(Clone)");
				CUBE.GetComponent<boxscriptV2>().enabled = false;
				GameObject CUBEPUT = GameObject.Find("/tableTrigger/putCard/I/Cube");
				CUBE.transform.position = CUBEPUT.transform.position + new Vector3(0,0.1f,0);
				CUBE.transform.rotation = Quaternion.Euler(0, 30, 45);		
				CUBE.transform.localScale = new Vector3(0.15f,0.15f,0.15f); 
				light = GameObject.Find("/tablePuzzleHint/indigoLight/light");
				light.GetComponent<Light>().enabled = true;
			}
			initIndigo = true;
		}
		
		if((violetOne + tiggerBox.violetHolder) == 2)
		{
			if(!initViolet)
			{
				GetComponent<AudioSource>().mute = false;
				bingoSource.Play();
				GameObject CUBE = GameObject.Find("/theVioletCube(Clone)");
				CUBE.GetComponent<boxscriptV2>().enabled = false;
				GameObject CUBEPUT = GameObject.Find("/tableTrigger/putCard/V/Cube");
				CUBE.transform.position = CUBEPUT.transform.position + new Vector3(0,0.1f,0);
				CUBE.transform.rotation = Quaternion.Euler(0, 30, 45);		
				CUBE.transform.localScale = new Vector3(0.15f,0.15f,0.15f); 
				light = GameObject.Find("/tablePuzzleHint/violetLight/light");
				light.GetComponent<Light>().enabled = true;
			}
			initViolet = true;
		}
    }
}
