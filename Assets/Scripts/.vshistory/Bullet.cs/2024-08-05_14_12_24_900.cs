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

        // If the object hit was the player and the bullet is not from the player, damage the player
        if (other.gameObject.tag == "Player" && !fromPlayer)
        {
            other.gameObject.GetComponent<Player>().OnDamage(damage);
            Destroy(gameObject);
        }

        // If the object hit was an enemy and the bullet is from the player, damage the enemy
        else if (other.gameObject.tag == "Enemy" && fromPlayer)
        {
            other.gameObject.GetComponent<Enemy>().OnDamage(damage);
            Destroy(gameObject);
        }

        else if(other.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
