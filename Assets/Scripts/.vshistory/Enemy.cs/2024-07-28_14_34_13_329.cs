using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to hold basic enemy properties and behaviors

public class Enemy : MonoBehaviour
{
    public int hp; // Maximum enemy HP

    // Event to damage enemy and handle death
    public void OnDamage(int damage)
    {
        // Reduce HP by bullet damage
        hp -= damage;

        // If HP is 0, kill the enemy
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
