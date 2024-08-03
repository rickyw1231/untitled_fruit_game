using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public Transform player; // Player position
    public GameObject bullet; // Bullet to shoot

    public float speed; // Speed of bullet
    public float delay; // Time between bullets

    private float countdown; // Used for timing the bullets

    void Start()
    {
        countdown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Count down the delay timer and determine whether the player can shoot
        bool playerCanShoot = CanShoot(countdown);

        // Shoot on left click and if the timer has finished
        if (Input.GetMouseButtonDown(0) && playerCanShoot)
        {
            countdown = delay;

            GameObject projectile = Instantiate(bullet, player.position, player.rotation);
            Vector3 direction = new Vector3(1f, 0f, 0f);
            Rigidbody projRB = projectile.GetComponent<Rigidbody>();
            projRB.AddForce(direction * speed);
        }
    }

    // Method to check if the player can shoot and handle the timer
    bool CanShoot(float count)
    {
        if(count <= 0)
        {
            count = 0;
            return true;
        }
        else
        {
            count -= Time.deltaTime;
            return false;
        }
    }
}
