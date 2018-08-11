using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;
    [SerializeField] State StartingState;

    State state;
	// Use this for initialization
	void Start () {
        state = StartingState;
        textComponent.text = state.getStateStory();
	}
	
	// Update is called once per frame
	void Update () {
        ManageState();
	}

    private void ManageState()
    {
        var nextStates = state.getNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = nextStates[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = nextStates[2];
        }
        textComponent.text = state.getStateStory();
    }
}
