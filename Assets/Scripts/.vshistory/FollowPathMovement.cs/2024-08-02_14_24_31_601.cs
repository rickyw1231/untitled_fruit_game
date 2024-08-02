using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{
    public Transform player; // Location of player for distance calculations
    public float range; // Distance from player in which enemy can move
    public float speed; // Speed of movement
    public Transform[] pathPoints; // Points on map to travel to in order
    public int startPoint; // Initial path point

    private Rigidbody rb; // Rigidbody of enemy

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
