using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolSlider : MonoBehaviour {

    public Slider slider;
        
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(slider.value);
        //SoundManagerScript.audioSrc.volume = slider.value;
        SoundManagerScript.masterVolume = 0.1f;
    }
}
