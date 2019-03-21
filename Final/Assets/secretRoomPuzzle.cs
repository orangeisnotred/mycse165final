using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretRoomPuzzle : MonoBehaviour
{
	GameObject p1;
	GameObject p2;
	GameObject p3;
	GameObject p4;
	bool puzzleFinished = false;
	// public AudioClip bingoClip;
	private AudioSource bingoSource;
	
    // Start is called before the first frame update
    void Start()
    {
        p1 = transform.GetChild(0).gameObject;
		p2 = transform.GetChild(1).gameObject;
		p3 = transform.GetChild(2).gameObject;
		p4 = transform.GetChild(3).gameObject;
		GetComponent<AudioSource>().mute = true;
		bingoSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(p1.transform.localRotation.eulerAngles.z < 3 || p1.transform.localRotation.eulerAngles.z > 357 )
		{
			if(p2.transform.localRotation.eulerAngles.z < 3 || p2.transform.localRotation.eulerAngles.z > 357 )
			{
				if(p3.transform.localRotation.eulerAngles.z < 3 || p3.transform.localRotation.eulerAngles.z > 357 )
				{
					if(p4.transform.localRotation.eulerAngles.z < 3 || p4.transform.localRotation.eulerAngles.z > 357 )
					{
						
						if (!puzzleFinished)
						{
							GetComponent<AudioSource>().mute = false;
							bingoSource.Play();
						}
						
						puzzleFinished = true;
					}
				}
			}
				
		}
		
		if(puzzleFinished)
		{
			p1.transform.localRotation = Quaternion.Euler(0, 0, 0);
			p2.transform.localRotation = Quaternion.Euler(0, 0, 0);
			p3.transform.localRotation = Quaternion.Euler(0, 0, 0);
			p4.transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
			

    }
}
