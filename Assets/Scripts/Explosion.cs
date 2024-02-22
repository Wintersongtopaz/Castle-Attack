using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float force, radius, modifier;
    public GameObject explosionFX;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(explosionFX, transform.position, Quaternion.identity);

        // Stop the explosion after a certain amount of time.
        Invoke("DestroyExplosion", 0.1f);
    }

    void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody)
        {
            // Determine the range and force of the explosion.
            rigidbody.AddExplosionForce(force, transform.position, radius, modifier, ForceMode.VelocityChange);
        }
    }

    void DestroyExplosion()
    {
        // Cause an explosion when a certain block is hit with cannonball.
        Destroy(gameObject);
    }
}
