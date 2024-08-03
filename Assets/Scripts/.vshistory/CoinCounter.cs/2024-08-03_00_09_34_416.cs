using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script to display the number of coins collected and the total number of coins in the UI

public class CoinCounter : MonoBehaviour
{
    public GameObject player; // For getting info about coins
    public Text coinInfo; // Text displaying coin information

    private int coinsCollected; // Coins collected by the player
    private int totalCoins; // Total number of coins in the map

    // Start is called before the first frame update
    void Start()
    {
        coinInfo.text = "0/0 Coins";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
