using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
    public static AudioClip grunt, pop, squish, portal;
    static AudioSource audioSrc;
	// Use this for initialization
	void Start () {
        grunt = Resources.Load<AudioClip>("grunt");
        pop = Resources.Load<AudioClip>("pop");
        squish = Resources.Load<AudioClip>("squish");
        portal = Resources.Load<AudioClip>("portal");

        audioSrc = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "grunt":
                audioSrc.PlayOneShot(grunt);
                break;
            case "pop":
                audioSrc.PlayOneShot(pop);
                break;
            case "squish":
                audioSrc.PlayOneShot(squish);
                break;
            case "portal":
                audioSrc.PlayOneShot(portal);
                break;


        }
    }
}
