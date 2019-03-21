using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skull : MonoBehaviour
{
	GameObject GREENLight;
	GameObject p1;
	GameObject p2;
	GameObject p3;
	GameObject p4;
	public static bool GREEN = false;

	
    // Start is called before the first frame update
    void Start()
    {
        GREENLight = GameObject.Find("/secretRoom/GREEN");
		p1 = GameObject.Find("/secretRoom/skull/1");
		p2 = GameObject.Find("/secretRoom/skull/2");
		p3 = GameObject.Find("/secretRoom/skull/3");
		p4 = GameObject.Find("/secretRoom/skull/4");

		
    }

    // Update is called once per frame
    void Update()
    {
		float x = p1.transform.localRotation.z *3 + p4.transform.localRotation.z*3 + 2.319f;
		float y = p2.transform.localRotation.z *3 + p4.transform.localRotation.z*3 + 76.675f;
		float z = p3.transform.localRotation.z *3 + p4.transform.localRotation.z*3 - 1.682f;
		Quaternion temp =  Quaternion.Euler(x, y, z);
        GREENLight.transform.rotation = temp;
		if( p1.transform.localRotation.z == 0 && p2.transform.localRotation.z == 0 && p3.transform.localRotation.z == 0 && p4.transform.localRotation.z == 0)
		{
			GREEN = true;
			// could implement sound effect here indicate successful 
		}

    }
}
