using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script to handle the behaviors surrounding the goal

public class Goal : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.type == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
