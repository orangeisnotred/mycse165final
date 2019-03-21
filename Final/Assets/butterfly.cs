using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterfly : MonoBehaviour
{
	GameObject REDLight;
	GameObject p1;
	GameObject p2;
	GameObject p3;
	GameObject p4;
	public static bool RED = false;

	
    // Start is called before the first frame update
    void Start()
    {
        REDLight = GameObject.Find("/secretRoom/RED");
		p1 = GameObject.Find("/secretRoom/butterfly/1");
		p2 = GameObject.Find("/secretRoom/butterfly/2");
		p3 = GameObject.Find("/secretRoom/butterfly/3");
		p4 = GameObject.Find("/secretRoom/butterfly/4");

		
    }

    // Update is called once per frame
    void Update()
    {
		float x = p1.transform.localRotation.z *3 + p4.transform.localRotation.z*3 + 15.779f;
		float y = p2.transform.localRotation.z *3 + p4.transform.localRotation.z*3 + 92.367f;
		float z = p3.transform.localRotation.z *3 + p4.transform.localRotation.z*3 - 6.644001f;
		Quaternion temp =  Quaternion.Euler(x, y, z);
        REDLight.transform.rotation = temp;
		
		if( p1.transform.localRotation.z == 0 && p2.transform.localRotation.z == 0 && p3.transform.localRotation.z == 0 && p4.transform.localRotation.z == 0)
		{
			
			RED = true;
			// could implement sound effect here indicate successful 
		}

    }
}
