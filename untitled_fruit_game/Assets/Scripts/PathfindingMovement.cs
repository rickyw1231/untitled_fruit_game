using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Script to handle pathfinding throughout the map

public class PathfindingMovement : MonoBehaviour
{
    public Transform player; // Location of player
    public NavMeshAgent agent; // Moving enemy
    public float range; // Distance from player in which enemy can move

    // Update is called once per frame
    void Update()
    {
        // Face the player
        transform.LookAt(player);
        
        // Move towards the player
        agent.SetDestination(player.position);

        // Zero the velocity if the player is within range
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance < range)
        {
            agent.velocity = Vector3.zero;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
    }
}
