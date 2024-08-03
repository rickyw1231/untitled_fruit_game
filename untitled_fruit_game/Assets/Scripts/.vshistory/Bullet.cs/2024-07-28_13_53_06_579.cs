using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for handling bullet properties and behaviors

public class Bullet : MonoBehaviour
{
    public int damage; // Damage dealt by the bullet

    // Method to trigger collision event
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().OnDamage(damage);
        }
    }

}
