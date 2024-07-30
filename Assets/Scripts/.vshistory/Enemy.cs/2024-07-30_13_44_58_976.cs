using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to hold basic enemy properties and behaviors

public class Enemy : MonoBehaviour
{
    public int hp; // Current enemy HP
    public HealthBar healthBar; // Enemy health bar

    private int maxHP; // Maximum enemy HP

    void Start()
    {
        maxHP = hp;
    }

    // Event to damage enemy and handle death
    public void OnDamage(int damage)
    {
        // Reduce HP by bullet damage
        hp -= damage;

        // Update the health bar
        healthBar.SetHP((float)hp / maxHP);

        // If HP is 0, kill the enemy
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
