using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached ref
    Level level;
    GameStatus gameStatus;

    //state variables
    [SerializeField] int timesHit=0; // only serialized for debug purposes
    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.countBlocks();
        }
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length+1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        if (hitSprites[timesHit - 1] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
        else
        Debug.LogError("Block sprite is missing from array "+gameObject.name);
    }

    private void DestroyBlock()
    {
       
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            level.BlocksDesroyed();
            gameStatus.addToScore();
            TriggerSparklesVfx();
            Destroy(gameObject);
       

    }

    private void TriggerSparklesVfx()
    {
        GameObject sparks = Instantiate(blockSparkesVFX,transform.position,transform.rotation);
        Destroy(sparks, 1f);
    }
}
