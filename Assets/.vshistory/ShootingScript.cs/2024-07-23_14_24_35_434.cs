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
    public float countDown; // Used for counting down

    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0)
        {
            countDown = delay;
            GameObject projectile = Instantiate(bullet, source.position);
            RigidBody projRB = projectile.GetComponent<RigidBody>();
            Vector3 direction = Vector3.Normalize(target.position - source.position);
            projRB.AddForce(direction * speed);
        }
    }
}
