using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;

    public GameObject grenadeObject;

    public float grenadeRate = 5f;
    private float nextFire;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Time.time > nextFire)
        {
            ThrowGrenade();
            nextFire = Time.time + grenadeRate;
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadeObject, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
