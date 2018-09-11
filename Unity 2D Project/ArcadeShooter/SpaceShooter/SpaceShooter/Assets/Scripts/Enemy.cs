using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("stats")]
    [SerializeField] float health = 100;
    [SerializeField] float points = 75f;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 2f;
    [SerializeField] float maxTimeBetweenShots = 4f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed= 20f;




    [Header("effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;

    //sounds
    [Header("Sounds")]
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0, 1)] float laserVolume = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathVolume = 1f;

    [Header("BOSS")]
    [SerializeField] GameObject Boss2ndProjectile;


    // Use this for initialization
    void Start () {

        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}
	
	// Update is called once per frame
	void Update () {
        CountDownAndShot();
	}

    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        if (this.tag == "BOSS")
        {
            FireThreeShots();
        }
        else
        {
            GameObject laser = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y - 0.2f), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
            AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserVolume);
        }
    }

    private void FireThreeShots()
    {
        GameObject laser = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y - 3.4f), Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserVolume);

        laser = Instantiate(projectile, new Vector2(transform.position.x-2.5f, transform.position.y - 0.7f), Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserVolume);

        laser = Instantiate(projectile, new Vector2(transform.position.x+2.5f, transform.position.y - 0.7f), Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dd = other.gameObject.GetComponent<DamageDealer>();
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
        FindObjectOfType<GameController>().AddToScore(points);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathVolume);
    }
}
