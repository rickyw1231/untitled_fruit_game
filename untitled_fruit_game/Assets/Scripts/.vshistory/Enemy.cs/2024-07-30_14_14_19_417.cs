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

        // If HP is 0, kill the enemy and try dropping an item 
        if(hp <= 0)
        {
            DropItem();
            Destroy(gameObject);
        }
    }

    // Method to drop an item on death
    private void DropItem()
    {
        // 1/3 chance to drop an item
        //int check = Random.Range(1, 3);
        //if(check == 3)
        //{
            Instantiate(item, transform);
        Debug.Log("blip")
        //}
    }
}
