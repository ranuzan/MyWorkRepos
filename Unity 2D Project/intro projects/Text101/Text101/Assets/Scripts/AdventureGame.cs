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
        for (int i = 0; i < nextStates.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1+i))
            {
                state = nextStates[i];
            }
        }
        textComponent.text = state.getStateStory();

    }
}
