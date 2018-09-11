using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    Text healthText;
    Player p;

    // Use this for initialization
    void Start () {
        healthText = GetComponent<Text>();
        p = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        healthText.text = p.GetHealth().ToString();
    }
}
