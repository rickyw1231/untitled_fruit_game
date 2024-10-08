using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to hold basic enemy properties and behaviors

public class Enemy : MonoBehaviour
{
    public int hp; // Current enemy HP
    public HealthBar healthBar; // Enemy health bar
    public GameObject item; // Item to drop on death
    public int dropChance; // Chance of dropping an item

    private int maxHP; // Maximum enemy HP
    private AudioManager audioManager; // For playing sound effects

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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

        // Play hit sound
        audioManager.PlaySound(audioManager.hit);

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
        // Drop an item through RNG
        int check = Random.Range(1, 101);
        if(check <= dropChance)
        {
            Vector3 position = new Vector3(transform.position.x, 0.25f, transform.position.z);
            Instantiate(item, position, Quaternion.identity);
        }
    }
}
