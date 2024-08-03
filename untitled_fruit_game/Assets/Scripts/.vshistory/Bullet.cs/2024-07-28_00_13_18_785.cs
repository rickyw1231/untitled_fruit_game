using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for handling bullet properties and behaviors

public class Bullet : MonoBehaviour
{
    public int damage; // Damage dealt by the bullet

    // Event to destroy the bullet after collision
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
