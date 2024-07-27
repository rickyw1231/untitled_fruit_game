using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public Transform player; // Player position
    public GameObject bullet; // Bullet to shoot

    public float speed; // Speed of bullet
    public float delay; // Time between bullets

    private float countdown;

    void Start()
    {
        countdown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Shoot on left click
        if(Input.GetMouseButtonDown(0) && CanShoot(countdown))
        {
            countdown = delay;

            GameObject projectile = Instantiate(bullet, player.position, player.rotation);
            Vector3 direction = new Vector3(1f, 0f, 0f);
            Rigidbody projRB = projectile.GetComponent<Rigidbody>();
            projRB.AddForce(direction * speed);
        }
    }

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
