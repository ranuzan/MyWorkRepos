using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*this simple game guesses your number in a binary search way and prints it to console*/
public class NumberWizard : MonoBehaviour {
    int min = 1;
    int max = 1000;
    int guess = 500;
    // Use this for initialization
    void Start () {
        min = 1;
        max = 1000;
        guess = (max + min) / 2;

        Debug.Log("pick a num between "+min+ " to "+max);
        Debug.Log("current guess is " + guess);
        Debug.Log("up = higher -   down = lower  -  enter = correct");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            guess = (max + min) / 2;
            Debug.Log("current guess is " + guess);
            Debug.Log("up = higher -   down = lower  -  enter = correct");
            if (guess == 999)
            {
                max += 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            guess = (max + min) / 2;
            Debug.Log("current guess is " + guess);
            Debug.Log("up = higher -   down = lower  -  enter = correct");
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("your number is " + guess);
        }
    }
}
