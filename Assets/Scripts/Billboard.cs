using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to allow enemy health bars to face the camera

public class Billboard : MonoBehaviour
{
    public Transform cam; // Camera position

    // Method to face the camera
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
