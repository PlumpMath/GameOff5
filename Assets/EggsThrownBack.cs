using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggsThrownBack : MonoBehaviour {

    private Score score;

    Text text;                      // Reference to the Text component.

    // Use this for initialization
    void Start()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        score = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Eggs Thrown Back: " + score.EggsThrownBack;
    }
}
