using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
	GameObject BLUELight;
	GameObject p1;
	GameObject p2;
	GameObject p3;
	GameObject p4;
	public static bool BLUE = false;
	
    // Start is called before the first frame update
    void Start()
    {
        BLUELight = GameObject.Find("/secretRoom/BLUE");
		p1 = GameObject.Find("/secretRoom/fish/1");
		p2 = GameObject.Find("/secretRoom/fish/2");
		p3 = GameObject.Find("/secretRoom/fish/3");
		p4 = GameObject.Find("/secretRoom/fish/4");

		
    }

    // Update is called once per frame
    void Update()
    {
		float x = p1.transform.localRotation.z *3 + p4.transform.localRotation.z*3 + 2.966f;
		float y = p2.transform.localRotation.z *3 + p4.transform.localRotation.z*3 + 105.32f;
		float z = p3.transform.localRotation.z *3 + p4.transform.localRotation.z*3 - 1.06f;
		Quaternion temp =  Quaternion.Euler(x, y, z);
        BLUELight.transform.rotation = temp;
		if( p1.transform.localRotation.z == 0 && p2.transform.localRotation.z == 0 && p3.transform.localRotation.z == 0 && p4.transform.localRotation.z == 0)
		{
			BLUE = true;
			// could implement sound effect here indicate successful 
		}


    }
}
