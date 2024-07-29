using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle basic coin behaviors

public class Coin : MonoBehaviour
{
    public float speed; // Speed of rotation

    // Update is called once per frame
    void Update()
    {
        // Spin the coin
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    // Method to allow coin to be collected by the player
    public void OnTriggerEnter(Collider other)
    {
        // Increment the player's coin count
        if(other.gameObject.tag == "Player")
        {
            // Collect, delete the coin
            other.GetComponent<Player>().OnCoinCollect();
            Destroy(gameObject);

            // Check if all coins have been collected
            if(other.GetComponent<Player>().CollectedAllCoins())
            {
                Debug.Log("collected")
            }
        }
    }
}
