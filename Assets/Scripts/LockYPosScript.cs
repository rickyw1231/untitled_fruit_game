using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lock the object to a specified Y-axis position

public class LockYPosScript : MonoBehaviour
{
    public float yAxis; // Y-axis position to lock to

    // Update is called once per frame
    void Update()
    {
        // Lock the object to the y-axis position if it moves out of it
        if(transform.position.y != yAxis)
        {
            transform.position = new Vector3(transform.position.x, yAxis, transform.position.z);
        }
    }
}
