using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public Transform player; // Location of player for distance calculations
    public float timer; // Time between movement switching, if applicable

    private float countdown; // Used for counting down the timer
    private Rigidbody rb; // Rigidbody of enemy

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidboody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move if far away enough from the player
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance >= range)
        {
            // Switch direction after countdown
            if (countdown <= 0)
            {
                // Reset the countdown
                countdown = timer;

                // Stop current movement
                Rigidbody rb = gameObject.GetComponent<Rigidboody>();
                rb.velocity = Vector3.zero;

                // Generate a random direction, multiply it by the speed, and move
                Vector3 direction = Vector3.Normalize(new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)));
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
}
