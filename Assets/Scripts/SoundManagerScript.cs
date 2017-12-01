using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
    public static AudioClip grunt, pop, squish, portal;
    public static AudioSource audioSrc;
    public AudioSource songSrc;
    public static float songVolume;
    public static float masterVolume;
	// Use this for initialization
	void Start () {
        grunt = Resources.Load<AudioClip>("grunt");
        pop = Resources.Load<AudioClip>("pop");
        squish = Resources.Load<AudioClip>("squish");
        portal = Resources.Load<AudioClip>("portal");

        audioSrc = GetComponents<AudioSource>()[0];
        audioSrc.volume = masterVolume;
        songSrc.volume = songVolume;
        songSrc.Play();

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
