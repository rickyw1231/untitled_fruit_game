using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to allow the player to shoot

public class PlayerShootScript : MonoBehaviour
{
    private readonly float _timeToDestroy = 3f; // Time until a bullet is destroyed

    public Transform player; // Player body
    public Transform source; // Player gun position
    public Transform crossHair; // Crosshair position
    public GameObject bullet; // Bullet to shoot

    public float speed; // Speed of bullet
    public float delay; // Time between bullets

    private float countdown; // Used for timing the bullets
    private AudioManager audioManager; // For playing sound effects

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        countdown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the mouse position and face it
        Vector3 mousePos = Aim();
        player.LookAt(new Vector3(mousePos.x, player.position.y, mousePos.z));

        // Set the crosshair
        crossHair.position = mousePos;

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
        // Allow shooting if timer is up
        if(countdown <= 0)
        {
            countdown = 0;
            return true;
        }
        // Otherwise keep counting
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

        // Calculate the mouse position if possible
        if(Physics.Raycast(ray, out mousePos, Mathf.Infinity, 1))
        {
            // Reset the y-position of the vector so that the player doesn't rotate
            Vector3 mousePosToVector = mousePos.point;
            Vector3 correctedMousePos = new Vector3(mousePosToVector.x, 0f, mousePosToVector.z);
            return correctedMousePos;
        }
        else
        {
            return new Vector3(0f, 0f, 0f);
        }
    }
}
