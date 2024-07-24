using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public GameObject bullet; // Type of bullet to shoot
    public Transform source; // Position of source
    public Transform target; // Object to shoot at

    public float speed; // Speed of bullet
    public float delay; // Time between shooting periods
    public int numBullets; // Number of bullets to shoot
    public float timeBtwnBulls; // Time between shooting in the case of multiple bullets

    //[HideInInspector]
    private float periodCountDown; // For counting down between shooting periods

    //[HideInInspector]
    private float bulletCountDown; // For counting down between bullets

    //[HideInInspector]
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
        periodCountDown -= Time.deltaTime;
        if (periodCountDown <= 0)
        {
            if (bulletsToShoot >= 0)
            {
                bulletCountDown -= Time.deltaTime;
                if(bulletCountDown <= 0)
                {
                    bulletsToShoot--;
                    Shoot();
                }
            }
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
        GameObject projectile = Instantiate(bullet, source);
        Rigidbody projRB = projectile.GetComponent<Rigidbody>();
        Vector3 direction = Vector3.Normalize(target.position - source.position);
        projRB.AddForce(direction * speed);
    }
}
