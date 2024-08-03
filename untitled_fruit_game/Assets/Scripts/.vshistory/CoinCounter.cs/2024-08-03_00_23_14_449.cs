using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script to display the number of coins collected and the total number of coins in the UI

public class CoinCounter : MonoBehaviour
{
    public TextMeshPro coinInfo; // Text displaying coin information
    public int totalCoins; // Total number of coins in the map

    private int coinsCollected; // Coins collected by the player

    // Start is called before the first frame update
    void Start()
    {
        coinsCollected = 0;
        coinInfo.text = "0/" + totalCoins.ToString() + " Coins";
    }

    // Method to increment the coin counter and update the text
    public void AddCoin()
    {
        coinsCollected++;
        coinInfo.text = coinsCollected.ToString() + "/" + totalCoins.ToString() + " Coins";
    }
}
