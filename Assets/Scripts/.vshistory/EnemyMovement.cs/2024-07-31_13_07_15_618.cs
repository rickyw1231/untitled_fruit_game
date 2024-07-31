using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to allow enemies to move

// Enums for each type of movement
public enum MovementType
{
    RandomMovement // Move in random directions
}

public class EnemyMovement : MonoBehaviour
{
    public MovementType movementType; // Assigned movement type
    public Transform player; // Location of player for distance calculations
    public float range; // Distance from player in which enemy can move
    public float speed; // Speed of movement
    public float timer; // Time between movement switching, if applicable

    public float distance; // Distance between player and enemy
    public float countdown; // Used for counting down from the timer
    public int direction; // Direction of movement from list
    public Vector3 displacement; // Amount to move

    public string debug;

    private delegate void MovementDelegate(); // Used for calling methods for each movement type
    private static Dictionary<MovementType, MovementDelegate> movementHandler; // Data drives movement methods
    private static List<Vector3> directions; // List of vectors for direction

    // Start is called before the first frame update
    void Start()
    {
        movementHandler = new Dictionary<MovementType, MovementDelegate>
        {
            { 
                MovementType.RandomMovement, RandomMovement
            }
        };

        directions = new List<Vector3>
        {
            new(0f, 0f, 1f),
            new(1f, 0f, 0f),
            new(0f, 0f, -1f),
            new(-1f, 0f, 0f),
            new(0.7f, 0f, 0.7f),
            new(-0.7f, 0f, -0.7f),
            new(0.7f, 0f, -0.7f),
            new(-0.7f, 0f, 0.7f),
        };

        countdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Move based off of the movement type
        MovementDelegate move = movementHandler[movementType];
        move();
    }

    // Method to handle random movement
    private void RandomMovement()
    {
        // Move if far away enough from the player
        distance = Vector3.Distance(player.position, transform.position);
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
                int direction = Random.Range(0, 8);
                Vector3 displacement = directions[direction] * Time.deltaTime * speed;
                rb.AddForce(displacement);
            }
            // Otherwise continue the countdown
            else
            {
                countdown -= Time.deltaTime;
            }

            // Move the enemy
            transform.position += displacement;
        }
        // Otherwise reset the countdown and don't move
        else
        {
            countdown = 0;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
    }
}
