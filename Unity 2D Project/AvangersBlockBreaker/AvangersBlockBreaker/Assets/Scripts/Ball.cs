using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    [SerializeField] Vector2 currentVelocity;

    //cached  componenet refrance
    AudioSource myAudioSouce;
    Rigidbody2D myRigidBody2d;

    // Use this for initialization
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSouce = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        currentVelocity = myRigidBody2d.velocity;
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        fixSpeed();


    }

    private void fixSpeed()
    {
        if (myRigidBody2d.velocity.y<8)
        {
            if(myRigidBody2d.velocity.y < 0  && myRigidBody2d.velocity.y > -8)

            myRigidBody2d.velocity += new Vector2(0,-1);

            if(myRigidBody2d.velocity.y > 0)
            {
                myRigidBody2d.velocity += new Vector2(0, 1);
            }
        }

        if(myRigidBody2d.velocity.x < 1.5 && myRigidBody2d.velocity.x > 0)
        {
            myRigidBody2d.velocity += new Vector2(1, 0);

        }
        else if(myRigidBody2d.velocity.x < 0 && myRigidBody2d.velocity.x > -1.5)
        {
            myRigidBody2d.velocity += new Vector2(-1, 0);

        }
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButton(0))
        {
            myRigidBody2d.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSouce.PlayOneShot(clip);
            myRigidBody2d.velocity += velocityTweak;
        }
    }
}
