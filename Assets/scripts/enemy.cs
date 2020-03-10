using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody[] bodies;
    public bool isDead = false;
    GameObject player;

    void Start()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void GotHit()
    {
        isDead = true;
        for (int i = 0; i < bodies.Length; i++)
            bodies[i].isKinematic = false;
    }
}
