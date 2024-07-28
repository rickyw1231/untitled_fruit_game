using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for handling bullet properties and behaviors

public class Bullet : MonoBehaviour
{
    public int damage; // Damage dealt by the bullet
    public bool fromPlayer; // Flag to check if the bullet is from the player

    // Method to trigger collision event
    public void OnTriggerEnter(Collider other)
    {
        // Destroy the bullet on collision
        Destroy(gameObject);

        // If the object hit was the player and the bullet is not from the player, damage the player
        if(other.tag == "Player" && !fromPlayer)
        {
            Debug.Log(other.gameObject.tag);
            //other.gameObject.GetComponent<Player>().OnDamage(damage);
        }
    }

}
