using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for handling bullet properties and behaviors

public class Bullet : MonoBehaviour
{
    public int damage; // Damage dealt by the bullet

    public void OnDestroy()
    {
        Destroy(this);
    }
}
