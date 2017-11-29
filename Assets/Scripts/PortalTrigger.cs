using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onTriggerEnter2D(Collider other)
    {
        Debug.Log("enter trigger");
        SoundManagerScript.PlaySound("portal");
        Destroy(other.gameObject);
       
    }
}
