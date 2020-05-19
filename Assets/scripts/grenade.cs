using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;

    float countdown;
    bool hasExploded = false;

    public GameObject explosionEffect;
    public GameObject fireLight;

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    private void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        GameObject fireLamp = Instantiate(fireLight, transform.position, Quaternion.identity);
        Destroy(fireLamp, 0.1f);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider objects in colliders)
        {
            enemy enemeyHit = objects.transform.root.GetComponent<enemy>();
            if (enemeyHit != null)
            {
                enemeyHit.GotHit();
            }

            Rigidbody rb = objects.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
