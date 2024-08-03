using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to allow the player to shoot

public class PlayerShootScript : MonoBehaviour
{
    private readonly float _timeToDestroy = 3f; // Time until a bullet is destroyed

    public Transform player; // Player position
    public Transform source; // Player gun position
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
        Vector3 mousePos = Aim();
        player.LookAt(mousePos);

        // Count down the delay timer and determine whether the player can shoot
        bool playerCanShoot = CanShoot();

        // Shoot on left click and if the timer has finished
        if (Input.GetMouseButtonDown(0) && playerCanShoot)
        {
            // Reset the timer
            countdown = delay;

            // Shoot the bullet
            GameObject projectile = Instantiate(bullet, source.position, source.rotation);
            Vector3 direction = Vector3.Normalize(mousePos - source.position);
            Rigidbody projRB = projectile.GetComponent<Rigidbody>();
            projRB.AddForce(direction * speed);

            // Destroy the bullet after a period of time
            Destroy(projectile, _timeToDestroy);
        }
    }

    // Method to check if the player can shoot and handle the timer
    private bool CanShoot()
    {
        if(countdown <= 0)
        {
            countdown = 0;
            return true;
        }
        else
        {
            countdown -= Time.deltaTime;
            return false;
        }
    }

    // Method to aim 
    private Vector3 Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mousePos;

        if(Physics.Raycast(ray, out mousePos, Mathf.Infinity, 1))
        {
            Vector3 mousePosToVector = mousePos.point;
            Vector3 correctedMousePos = new Vector3(mousePosToVector.x, 1f, mousePosToVector.z);
            return correctedMousePos;
        }
        else
        {
            return new Vector3(0f, 1f, 0f);
        }
    }
}
