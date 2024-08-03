using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to prevent rotations in the Y and Z axes

public class LockRotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = transform.eulerAngles;
        transform.eulerAngles = new Vector3(eulerAngles.x, 0f, 0f);
    }
}
