using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody[] bodies;
    public bool isDead = false;
    GameObject player;

    Animator anim;

    public GameObject gun;

    void Start()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
    }

    public void GotHit()
    {
        if (isDead)
            return;

        gun.transform.parent = null;
        anim.enabled = false;
        isDead = true;
        for (int i = 0; i < bodies.Length; i++)
            bodies[i].isKinematic = false;
    }
}
