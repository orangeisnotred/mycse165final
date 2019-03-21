using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorfulLight : MonoBehaviour
{
	GameObject light1;
	GameObject light2;
	GameObject light3;
	GameObject light4;
	GameObject light5;
	GameObject light6;
	GameObject light7;
	Color R;
	Color O;
	Color Y;
	Color G;
	Color B;
	Color I;
	Color V;
	float t;
    // Start is called before the first frame update
    void Start()
    {
        light1 = GameObject.Find("light1/Spot Light");
		light2 = GameObject.Find("light2/Spot Light");
		light3 = GameObject.Find("light3/Spot Light");
		light4 = GameObject.Find("light4/Spot Light");
		light5 = GameObject.Find("light5/Spot Light");
		light6 = GameObject.Find("light6/Spot Light");
		light7 = GameObject.Find("light7/Spot Light");
		R = new Color(255,0,0,255);
		O = new Color(255,129,0,255);
		Y = new Color(255,253,0,255);
		G = new Color(37,255,0,255);
		B = new Color(29,0,255,255);
		I = new Color(0,255,249,255);
		V = new Color(231,0,255,255);
		
		t = Time.time;
    }

    // Update is called once per frame
    void Update()
    {	
		if (Time.time - t<0.5)
		{
			light1.GetComponent<Light>().color = R;
			light2.GetComponent<Light>().color = O;
			light3.GetComponent<Light>().color = Y;
			light4.GetComponent<Light>().color = G;
			light5.GetComponent<Light>().color = B;
			light6.GetComponent<Light>().color = I;
			light7.GetComponent<Light>().color = V;
		}
		else if (Time.time - t<1)
		{
			light2.GetComponent<Light>().color = R;
			light3.GetComponent<Light>().color = O;
			light4.GetComponent<Light>().color = Y;
			light4.GetComponent<Light>().color = G;
			light6.GetComponent<Light>().color = B;
			light7.GetComponent<Light>().color = I;
			light1.GetComponent<Light>().color = V;
		}
		else if (Time.time - t<1.5)
		{
			light3.GetComponent<Light>().color = R;
			light4.GetComponent<Light>().color = O;
			light5.GetComponent<Light>().color = Y;
			light6.GetComponent<Light>().color = G;
			light7.GetComponent<Light>().color = B;
			light1.GetComponent<Light>().color = I;
			light2.GetComponent<Light>().color = V;
		}
		else if (Time.time - t<2)
		{
			light4.GetComponent<Light>().color = R;
			light5.GetComponent<Light>().color = O;
			light6.GetComponent<Light>().color = Y;
			light7.GetComponent<Light>().color = G;
			light1.GetComponent<Light>().color = B;
			light2.GetComponent<Light>().color = I;
			light3.GetComponent<Light>().color = V;
		}
		else if (Time.time - t<2.5)
		{
			light5.GetComponent<Light>().color = R;
			light6.GetComponent<Light>().color = O;
			light7.GetComponent<Light>().color = Y;
			light1.GetComponent<Light>().color = G;
			light2.GetComponent<Light>().color = B;
			light3.GetComponent<Light>().color = I;
			light4.GetComponent<Light>().color = V;
		}
		else if (Time.time - t<3)
		{
			light6.GetComponent<Light>().color = R;
			light7.GetComponent<Light>().color = O;
			light1.GetComponent<Light>().color = Y;
			light2.GetComponent<Light>().color = G;
			light3.GetComponent<Light>().color = B;
			light4.GetComponent<Light>().color = I;
			light5.GetComponent<Light>().color = V;
		}
		else if (Time.time - t<3.5)
		{
			light7.GetComponent<Light>().color = R;
			light1.GetComponent<Light>().color = O;
			light2.GetComponent<Light>().color = Y;
			light3.GetComponent<Light>().color = G;
			light4.GetComponent<Light>().color = B;
			light5.GetComponent<Light>().color = I;
			light6.GetComponent<Light>().color = V;
		}
		else
		{
			t = Time.time;
		}
        
    }
}
