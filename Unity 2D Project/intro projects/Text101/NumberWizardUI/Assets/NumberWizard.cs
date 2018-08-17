using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*this simple game guesses your number in a binary search way and prints it to console*/
public class NumberWizard : MonoBehaviour {
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] int guess;
    [SerializeField] TextMeshProUGUI guessText;

    // Use this for initialization
    void Start () {
        nextguess();
    }

    // Update is called once per frame
    void Update () {

    }
    public void onPressHiger()
    {
        min = guess+1;
        nextguess();
        return;
    }
    public void onPressLower()
    {
        max = guess+1;
        nextguess();
        return;
    }
    public void nextguess()
    {
        guess = Random.Range(min,max+1); ;
        guessText.text = (guess.ToString());
    }

}
