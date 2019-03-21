using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretRoomTrigger : MonoBehaviour
{
	GameObject rightHand;
	Collider m_ObjectCollider;
    // Start is called before the first frame update
	void OnTriggerStay(Collider col)
    {
		if(m_ObjectCollider.isTrigger)
		{
			if (col.gameObject.tag == "right")
			{
				// if (rightHand.transform.GetComponent<Raycasttest>().isHolding)
				// {

				GameObject secretRoomWall = GameObject.Find("/secretRoomWall");
				secretRoomWall.GetComponent<Rigidbody>().velocity = new Vector3(0, 2, 0);
					// GameObject secretRoom = GameObject.Find("/secretRoom");
					// secretRoom.GetComponent<Rigidbody>().velocity = new Vector3(0, 2, 0);
				// }
			
			
			}
		}
        // Debug.Log("collided");
        

    }
	
	
    void Start()
    {
        m_ObjectCollider = GetComponent<Collider>();
		rightHand = GameObject.Find("hand_right");
    }

    // Update is called once per frame
    void Update()
    {
        if (butterfly.RED == true && fish.BLUE == true && skull.GREEN == true)
		{
			m_ObjectCollider.isTrigger = true;
			// Debug.Log("ALLRIGHT: "+GameObject.GetComponent<BoxCollider>().isTrigger);
		}
    }
}
