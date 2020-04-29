using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody[] bodies;
    public bool isDead = false;
    GameObject player;

    Animator anim;

    void Start()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
    }

    public void GotHit()
    {
        anim.enabled = false;
        isDead = true;
        for (int i = 0; i < bodies.Length; i++)
            bodies[i].isKinematic = false;
    }
}
