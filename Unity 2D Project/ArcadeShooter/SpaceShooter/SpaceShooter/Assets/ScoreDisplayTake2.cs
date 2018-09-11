using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayTake2 : MonoBehaviour {


    Text textScore;
    GameController gc;

    // Use this for initialization
    void Start () {
        textScore = GetComponent<Text>();
        gc = FindObjectOfType<GameController>();

    }
	
	// Update is called once per frame
	void Update () {
        textScore.text = gc.getScore().ToString();
        Debug.Log("score is: " + gc.getScore().ToString() + " at");


    }
}
