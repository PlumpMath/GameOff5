using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int AliensEscaped;
    public int EggsThrownBack;
    public int AliensKilled;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AlienEscaped()
    {
        AliensEscaped++;
        Debug.Log(AliensEscaped);
    }

    public void EggThrownBack()
    {
        EggsThrownBack++;
        Debug.Log(EggsThrownBack);
    }

    public void AlienKilled()
    {
        AliensKilled++;
        Debug.Log(AliensKilled);
    }

}
