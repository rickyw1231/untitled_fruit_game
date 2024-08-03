using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle moving along a set path

public class FollowPathMovement : MonoBehaviour
{
    public Transform player; // Location of player for distance calculations
    public float range; // Distance from player in which enemy can move
    public float speed; // Speed of movement
    public Transform[] pathPoints; // Points on map to travel to in order
    public int startPoint; // Initial path point

    private Rigidbody rb; // Rigidbody of enemy
    private float prevDistToPoint; // Distance to next path point in previous frame
    private int pathNum; // Path point currently being traveled to
    private Vector3 velocity; // Stored current velocity
    private Vector3 direction; // Direction to move in

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        prevDistToPoint = 0f;
        pathNum = startPoint;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the velocity
        // This ensures that the enemy will consistently move towards the point after stopping
        rb.velocity = velocity;

        // Move if far enough from the player
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance >= range)
        {
            // Determine if the distance to the next point is the same as the one from the previous frame
            // This allows us to check for intersections
            float distanceToPoint = Vector3.Distance(pathPoints[pathNum].position, transform.position);
            if (distanceToPoint <= prevDistToPoint)
            {
                prevDistToPoint = distanceToPoint;
            }
            // If so, head to the next point
            else
            {
                pathNum++;
                if (pathNum >= pathPoints.Length)
                {
                    pathNum = 0;
                }

                // Move towards the new point
                prevDistToPoint = Vector3.Distance(pathPoints[pathNum].position, transform.position);
                direction = Vector3.Normalize(pathPoints[pathNum].position - transform.position);
                velocity = direction * speed;
            }
        }
        // Otherwise don't move
        else
        {
            rb.velocity = Vector3.zero;
        }

        // Look in the direction of movement
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }
}
