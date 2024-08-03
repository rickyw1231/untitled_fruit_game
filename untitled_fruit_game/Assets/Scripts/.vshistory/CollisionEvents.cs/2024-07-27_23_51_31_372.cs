using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CollisionEvents : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onTriggerEnter;

    private void OnTriggerEnter()
    {
        _onTriggerEnter?.Invoke();
    }
}
