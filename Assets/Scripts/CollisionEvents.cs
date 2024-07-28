using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

// Collision event handler

public class CollisionEvents : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onTriggerEnter; // Events to trigger

    // Method to trigger event
    private void OnTriggerEnter()
    {
        Debug.Log("hit");
        _onTriggerEnter?.Invoke();
    }
}
