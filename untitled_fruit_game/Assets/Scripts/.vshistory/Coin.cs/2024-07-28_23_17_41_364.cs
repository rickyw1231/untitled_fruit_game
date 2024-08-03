using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle basic coin behaviors

public class Coin : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(0, 30 * Time.deltaTime, 0);
    }

    // Method to allow coin to be collected by the player
    public void OnTriggerEnter(Collider other)
    {
        // Increment the player's coin count
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Player>().OnCoinCollect();
            Destroy(gameObject);
        }
    }
}
