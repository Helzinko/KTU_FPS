using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;

    public GameObject grenadeObject;

    public float grenadeRate = 5f;
    private float nextFire;

    float countdown;
    public float delay = 3f;

    private bool canCount = false;

    public AudioSource explosionSound;
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && Time.time > nextFire)
        {
            ThrowGrenade();
            nextFire = Time.time + grenadeRate;
            canCount = true;
        }

        if(canCount)
            countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            Debug.Log("Test");
            explosionSound.Play();
            countdown = delay;
            canCount = false;
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadeObject, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
