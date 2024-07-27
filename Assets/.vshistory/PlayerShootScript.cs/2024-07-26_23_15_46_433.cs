using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public Transform player; // Player position
    public GameObject bullet; // Bullet to shoot

    public float speed; // Speed of bullet
    public float delay; // Time between bullets

    // Update is called once per frame
    void Update()
    {
        // Shoot on left click
        if(Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(bullet, player.position, player.rotation);
            Vector3 direction = new Vector3(1f, 0f, 0f);
            Rigidbody projRB = projectile.GetComponent<Rigidbody>();
            projRB.AddForce(direction * speed);
        }
    }
}
