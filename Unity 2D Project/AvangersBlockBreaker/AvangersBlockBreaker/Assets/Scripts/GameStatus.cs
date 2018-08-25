using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameStatus : MonoBehaviour {

    //params
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] float pointPerBlockDesroyed = 52f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    internal string GetScore()
    {
        return currentScore.ToString();
    }


    //state
    [SerializeField] float currentScore = 0;


    // Use this for initialization

    private void Awake()
    {
        GameStatus[] gameStatuses = FindObjectsOfType<GameStatus>();
        gameStatuses[0].resetScore();
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start () {
        scoreText.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
	}
    public void addToScore()
    {
        currentScore += pointPerBlockDesroyed;

    }
    public void resetScore()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}   

