using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to allow enemies to shoot

public class ShootingScript : MonoBehaviour
{
    private readonly float _timeToDestroy = 5.0f; // Time until bullet is deleted

    public GameObject bullet; // Type of bullet to shoot
    public Transform source; // Position of source
    public Transform target; // Object to shoot at

    public float speed; // Speed of bullet
    public float delay; // Time between shooting periods
    public int numBullets; // Number of bullets to shoot
    public float timeBtwnBulls; // Time between shooting in the case of multiple bullets

    public float requiredDistance; // Distance from player needed to begin shooting

    [HideInInspector]
    private float periodCountDown; // For counting down between shooting periods

    [HideInInspector]
    private float bulletCountDown; // For counting down between bullets

    [HideInInspector]
    private float bulletsToShoot; // For determining the number of bullets left to shoot

    void Start()
    {
        periodCountDown = delay;
        bulletCountDown = timeBtwnBulls;
        bulletsToShoot = numBullets;
    }

    // Update is called once per frame
    void Update()
    {
        float actualDistance = Vector3.Distance(target.position, transform.position);
        if(actualDistance <= requiredDistance)
        {
            CountDown();
        }
        else
        {
            periodCountDown = delay;
            bulletCountDown = timeBtwnBulls;
            bulletsToShoot = numBullets;
        }
    }

    // Method to count down until shooting
    void CountDown()
    {
        // Face the player
        transform.LookAt(target);

        // Begin shooting after a certain time period
        periodCountDown -= Time.deltaTime;
        if (periodCountDown <= 0)
        {
            // If the enemy can still shoot, shoot
            if (bulletsToShoot > 0)
            {
                // Shoot after the bullet delay
                bulletCountDown -= Time.deltaTime;
                if (bulletCountDown <= 0)
                {
                    bulletsToShoot--;
                    bulletCountDown = timeBtwnBulls;
                    Shoot();
                }
            }
            // Otherwise, reset the period countdown and restart
            else
            {
                periodCountDown = delay;
                bulletsToShoot = numBullets;
            }
        }
    }

    // Method to shoot
    void Shoot()
    {
        // Create a bullet object and launch it in the direction of the player
        GameObject projectile = Instantiate(bullet, source.position, source.rotation);
        Vector3 direction = Vector3.Normalize(target.position - source.position);
        Rigidbody projRB = projectile.GetComponent<Rigidbody>();
        projRB.AddForce(direction * speed);

        // Destroy the bullet after a period of time
        Destroy(projectile, _timeToDestroy);
    }
}
