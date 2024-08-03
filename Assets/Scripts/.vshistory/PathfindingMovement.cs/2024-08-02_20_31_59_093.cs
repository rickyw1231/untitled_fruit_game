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

    private Rigidbody rb; // Rigidbody of enemy

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance < range)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            Vector3 direction = Vector3.Normalize(rb.velocity);
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rotation;
        }
    }
}
