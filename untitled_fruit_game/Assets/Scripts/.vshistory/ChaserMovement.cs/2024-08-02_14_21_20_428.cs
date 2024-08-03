using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle chaser movement

public class ChaserMovement : MonoBehaviour
{
    public Transform player; // Location of player for distance calculations
    public float timer; // Time between movement switching, if applicable
    public float range; // Distance from player in which enemy can move
    public float chaseRange; // Distance from player in which enemy begins chase
    public float speed; // Speed of movement

    private Rigidbody rb; // Rigidbody of enemy

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only move when player is within a certain distance range
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance >= range && distance <= chaseRange)
        {
            transform.LookAt(player);
            Vector3 direction = Vector3.Normalize(player.position - transform.position);
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
