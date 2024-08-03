using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Script to handle pathfinding throughout the map

public class PathfindingMovement : MonoBehaviour
{
    public Transform player; // Location of player
    public NavMeshAgent agent; // Moving enemy

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
}
