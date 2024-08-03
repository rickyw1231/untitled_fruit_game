using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthBar; // Health bar slider

    public void SetHP(int hp)
    {
        healthBar.value = hp;
    }
}
