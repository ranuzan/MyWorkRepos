using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScript : MonoBehaviour {

    [SerializeField] TextMeshProUGUI winScore;


    // Use this for initialization
    void Start () {
        GameStatus gs = FindObjectOfType<GameStatus>();
        if (gs != null)
        {
            winScore.text = gs.GetScore();
            Destroy(gs);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
