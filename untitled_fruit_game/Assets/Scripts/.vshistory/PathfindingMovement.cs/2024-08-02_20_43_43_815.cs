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
        transform.LookAt(player);
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance >= range)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(transform.position);
            agent.velocity = Vector3.zero;
        }
    }
}
