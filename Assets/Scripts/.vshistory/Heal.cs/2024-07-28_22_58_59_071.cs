using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle the basic behavior of the healing item

public class NewBehaviourScript : MonoBehaviour
{
    public int hpToHeal; // Amount of HP to heal

    // Method to heal the player on collision
    public void OnTriggerEnter(Collider other)
    {
        // If the player collects the heal, heal the player and delete the heal object
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().OnHeal(hpToHeal);
            Destroy(gameObject);
        }
    }
}
