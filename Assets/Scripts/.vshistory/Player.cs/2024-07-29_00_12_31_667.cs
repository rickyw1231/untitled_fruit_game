using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script to handle player information and player-related events

public class Player : MonoBehaviour
{
    public int hp; // The player's maximum HP
    public int coinsToWin; // Number of coins needed to win

    public HealthBar healthBar; // Player health bar

    private int maxHP; // Maximum HP used for comparison
    private int coinsCollected; // Number of coins collected by the player

    void Start()
    {
        maxHP = hp;
        healthBar.SetHP(hp);
    }

    // Event to damage the player
    public void OnDamage(int damage)
    {
        // Damage the player by the damage dealt by the bullet
        hp -= damage;

        // If the HP is 0, kill the player and reset the scene
        if (hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Event to heal the player
    public void OnHeal(int health)
    {
        // Increase the player's HP
        hp += health;

        // If the resulting HP exceeds the max HP, set the HP to max
        if (hp > maxHP)
        {
            hp = maxHP;
        }
    }

    // Event to collect a coin
    public void OnCoinCollect()
    {
        coinsCollected++;
    }

    // Method to determine whether all coins have been collected
    public bool CollectedAllCoins()
    {
        return coinsToWin == coinsCollected;
    }
}