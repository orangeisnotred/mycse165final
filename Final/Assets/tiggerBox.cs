using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiggerBox : MonoBehaviour
{
	public static int redHolder;
	public static int orangeHolder;
	public static int yellowHolder;
	public static int greenHolder;
	public static int blueHolder;
	public static int indigoHolder;
	public static int violetHolder;
	
	void OnTriggerEnter(Collider other)
    {
		// Debug.Log("Enter");
		if (other.gameObject.tag == "redHolder")
		{
			Debug.Log("redHolder");
			redHolder = 1;

		}
		
		if (other.gameObject.tag == "orangeHolder")
        {
			Debug.Log("orangeHolder");
			orangeHolder = 1;

        }
		
		if (other.gameObject.tag == "yellowHolder")
		{
			Debug.Log("yellowHolder");
			yellowHolder = 1;

		}
		
		if (other.gameObject.tag == "greenHolder")
        {
			Debug.Log("greenHolder");
			greenHolder = 1;

        }
		
		if (other.gameObject.tag == "blueHolder")
		{
			Debug.Log("blueHolder");
			blueHolder = 1;

		}
		
		if (other.gameObject.tag == "indigoHolder")
        {
			Debug.Log("indigoHolder");
			indigoHolder = 1;

        }
		
		if (other.gameObject.tag == "violetHolder")
        {
			Debug.Log("violetHolder");
			violetHolder = 1;

        }
		
		
	}
		
    // Start is called before the first frame update
    void Start()
    {
        redHolder = 0;
		orangeHolder = 0;
		yellowHolder = 0;
		greenHolder = 0;
		blueHolder = 0;
		indigoHolder = 0;
		violetHolder = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(redHolder);
    }
}
