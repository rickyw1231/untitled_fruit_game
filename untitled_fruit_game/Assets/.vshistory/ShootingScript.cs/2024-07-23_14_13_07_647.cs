using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public GameObject bullet; // Type of bullet to shoot
    public Transform source; // Position of source
    public Transform target; // Object to shoot at

    public float speed; // Speed of bullet
    public float delay; // Time between shooting

    // Update is called once per frame
    void Update()
    {
        GameObject projectile = Instantiate(bullet, source.position);
        RigidBody projRB = projectile.GetComponent<RigidBody>();
        Vector3 direction = source.position - target.position();
    }
}
