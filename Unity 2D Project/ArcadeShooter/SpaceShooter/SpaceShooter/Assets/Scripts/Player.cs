using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //config params
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] int health = 200;

    [Header("Projectile")]
    [SerializeField] GameObject laserPerfab;
    [SerializeField] float projectileSpeed = 10f;



    [SerializeField] float projectileFieringPeriod = 0.1f;

    //sounds
    [Header("Sounds")]
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0, 1)] float laserVolume = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float deathVolume=1f;


    Coroutine fieringCorutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Use this for initialization
    void Start () {
        SetUpMoveBoundaries();

    }
    // Update is called once per frame
    void Update () {
        Move();
        Fire();
	}

    private void Fire()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            fieringCorutine = StartCoroutine(FireContinuesly());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fieringCorutine);
        }
    }
    IEnumerator FireContinuesly()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPerfab, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserVolume);
            yield return new WaitForSeconds(projectileFieringPeriod);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dd = other.gameObject.GetComponent<DamageDealer>();
        if(!dd) { return; }
        ProcessHit(dd);

    }

    private void ProcessHit(DamageDealer dd)
    {
        health -= dd.GetDmg();
        dd.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathVolume);
        Destroy(gameObject);

        FindObjectOfType<LevelController>().LoadGameOver();
    }

    private void Move()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin+ padding, xMax- padding);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin+ padding, yMax - padding);

        transform.position = new Vector2(newXPos, newYPos);

    }
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

    }
    internal int GetHealth()
    {
        return health;
    }

}
