using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
