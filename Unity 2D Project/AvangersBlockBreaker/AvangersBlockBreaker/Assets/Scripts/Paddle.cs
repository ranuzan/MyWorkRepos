using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //config params
    [SerializeField] float screenWidthInUnits;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    //cached ref
    GameStatus gameStatus;
    Ball ball;
    // Use this for initialization
    void Start () {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update () {
        Vector2 PaddlePosition = new Vector2(transform.position.x, transform.position.y);
        PaddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = PaddlePosition;
	}

    private float GetXPos()
    {
        if (gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return ((Input.mousePosition.x / Screen.width) * screenWidthInUnits);

        }
    }
}
