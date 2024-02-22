using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Animator animator;
    public Transform fireSocket;
    public float rotationRate = 90.0f;
    public ParticleSystem fireFX;

    public int numProjectiles = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Control which direction the cannon is going to fire.
        float aimInput = Input.GetAxis("Horizontal");
        aimInput *= rotationRate * Time.deltaTime;
        transform.Rotate(Vector3.right * aimInput, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Fire the cannon when we press spacebar.
            Fire();
        }
    }

    void Fire()
    {
        // Cause the explosion to happen when we actually fire the cannon.
        animator.SetTrigger("Fire");
        Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);
        fireFX.Play();
        numProjectiles++;
    }
}
