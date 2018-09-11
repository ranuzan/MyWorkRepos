using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreDisplay : MonoBehaviour {

    TextMeshProUGUI textScore ;
    GameController gc;

	// Use this for initialization
	void Start () {

        textScore = GetComponent<TextMeshProUGUI>();
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update () {
        textScore.text=gc.getScore().ToString();
    }
}
