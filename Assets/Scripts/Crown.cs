using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    public GameObject explosion;
    // when this gameobject collides with another.
    void OnCollisionEnter(Collision collision)
    {
        //if other game object is ground.
        if (collision.gameObject.CompareTag("Ground"))
        {
            Score score = FindObjectOfType<Score>();
            if (score)
            {
                // End the level when the crown hits the ground.
                score.EndLevel();
            }
            
            if (explosion)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
