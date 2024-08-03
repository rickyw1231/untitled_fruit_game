using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to hold basic enemy properties and behaviors

public class Enemy : MonoBehaviour
{
    public int hp; // Current enemy HP
    public HealthBar healthBar; // Enemy health bar
    public GameObject item; // Item to drop on death

    private int maxHP; // Maximum enemy HP
    private Random rand; // Random number generator

    void Start()
    {
        maxHP = hp;
        rand = new Random();
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

    // Method to drop an item on death
    private void DropItem()
    {
        int check = rand.Next(1, 4);
        Debug.Log(check);
        if(check == 3)
        {
            Instantiate(item, source.position);
        }
    }
}
