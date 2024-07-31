using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to allow enemies to move

// Enums for each type of movement
public enum MovementType
{
    RandomMovement, // Move in random directions
    Chase // Chase the player within a certain distance
}

public class EnemyMovement : MonoBehaviour
{
    public MovementType movementType; // Assigned movement type
    public Transform player; // Location of player for distance calculations
    public float range; // Distance from player in which enemy can move
    public float chaseRange; // Distance from player in which enemy begins chase
    public float speed; // Speed of movement
    public float timer; // Time between movement switching, if applicable

    private float countdown; // Used for counting down the timer

    // Start is called before the first frame update
    void Start()
    {
        countdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Move based off of the movement type
        switch(movementType)
        {
            case MovementType.RandomMovement:
                RandomMovement();
                break;
            case MovementType.Chase:
                Chase();
                break;
        }
    }

    // Method to handle random movement
    private void RandomMovement()
    {
        // Move if far away enough from the player
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance >= range)
        {
            // Switch direction after countdown
            if (countdown <= 0)
            {
                // Reset the countdown
                countdown = timer;

                // Stop current movement
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;

                // Generate a random direction, multiply it by the speed, and move
                Vector3 direction = Vector3.Normalize(new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)));
                Vector3 displacement = direction * speed;
                rb.AddForce(displacement);
            }
            // Otherwise continue the countdown
            else
            {
                countdown -= Time.deltaTime;
            }
        }
        // Otherwise reset the countdown and don't move
        else
        {
            countdown = 0;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
    }

    // Method to chase the player within a certain range
    private void Chase()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance >= range && distance <= chaseRange)
        {
            Vector3 direction = Vector3.Normalize(player.position - gameObject.position);
        }
    }
}
