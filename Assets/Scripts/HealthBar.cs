using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script to handle health bar behaviors

public class HealthBar : MonoBehaviour
{
    public Slider healthBar; // Health bar slider

    // Method to set the value of the health bar
    public void SetHP(float hp)
    {
        healthBar.value = hp;
    }
}
