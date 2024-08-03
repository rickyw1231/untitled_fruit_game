using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle player information and player-related events

public class Player : MonoBehaviour
{
    public int hp; // The player's maximum HP

    public void OnDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
}
