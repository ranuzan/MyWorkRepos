using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] float score = 1f;

	// Use this for initialization
	void Awake () {
        SetUpSingelton();
    }

    private void SetUpSingelton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddToScore(float num)
    {
        this.score += num;
    }
    public float getScore()
    {
        return this.score;
    }
    public void ResetScore()
    {
        this.score = 0;
    }

}
