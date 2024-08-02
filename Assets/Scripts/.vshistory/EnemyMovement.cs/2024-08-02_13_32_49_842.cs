using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to allow enemies to move

// Enums for each type of movement
public enum MovementType
{
    RandomMovement, // Move in random directions
    Chase, // Chase the player within a certain distance
    Pathfind // Follow a specific path around the map
}

public class EnemyMovement : MonoBehaviour
{
    public MovementType movementType; // Assigned movement type
    public Transform player; // Location of player for distance calculations
    public float range; // Distance from player in which enemy can move
    public float chaseRange; // Distance from player in which enemy begins chase
    public float speed; // Speed of movement
    public float timer; // Time between movement switching, if applicable
    public Transform[] pathPoints; // Points on map to travel to in order

    private float countdown; // Used for counting down the timer
    private float distance; // Distance to player
    private Vector3 direction; // Direction to move in
    private Rigidbody rb; // Rigidbody of enemy
    public int pathNum; // Path point currently being traveled to
    private float distanceToPoint; // Distance to the next path point
    private float prevDistToPoint; // Distance to next path point in previous frame
    private Vector3 velocity; // Stored current velocity

    // Start is called before the first frame update
    void Start()
    {
        countdown = 0;
        pathNum = 0;
        prevDistToPoint = 0f;
        rb = gameObject.GetComponent<Rigidbody>();
        velocity = Vector3.zero;
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
            case MovementType.Pathfind:
                Pathfind();
                break;
        }
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
                rb.velocity = Vector3.zero;

                // Generate a random direction, multiply it by the speed, and move
                direction = Vector3.Normalize(new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)));
                Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = rotation;
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
            rb.velocity = Vector3.zero;
        }
    }

    // Method to chase the player within a certain range
    private void Chase()
    {
        // Only move when player is within a certain distance range
        distance = Vector3.Distance(player.position, transform.position);
        if (distance >= range && distance <= chaseRange)
        {
            transform.LookAt(player);
            direction = Vector3.Normalize(player.position - transform.position);
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    // Method to follow a path around the level
    private void Pathfind()
    {
        distance = Vector3.Distance(player.position, transform.position);
        if (distance >= range)
        {
            distanceToPoint = Vector3.Distance(pathPoints[pathNum].position, transform.position);
            direction = Vector3.Normalize(pathPoints[pathNum].position - transform.position);
            velocity = direction * speed;
            rb.velocity = velocity;
            Debug.Log("dist " + distanceToPoint);
            Debug.Log("prev dist " + prevDistToPoint);
            if(distanceToPoint < prevDistToPoint)
            {
                Debug.Log("yes");
                prevDistToPoint = distanceToPoint;
            }
            else
            {
                Debug.Log("no");
                pathNum++;
                if(pathNum >= pathPoints.Length)
                {
                    pathNum = 0;
                }
                prevDistToPoint = Vector3.Distance(pathPoints[pathNum].position, transform.position);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
