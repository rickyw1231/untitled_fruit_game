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
        agent.SetDestination(player.position);
    }
}
