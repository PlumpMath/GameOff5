﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVol : MonoBehaviour {

    public Slider slider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SoundManagerScript.songVolume = slider.value;
    }
}
