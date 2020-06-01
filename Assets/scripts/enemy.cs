using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody[] bodies;
    public bool isDead = false;
    GameObject player;

    public bool isBoss = false;

    Animator anim;

    public GameObject gun;

    private GameObject master;

    public AudioSource enemyHitSound;

    void Start()
    {
        bodies = GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
    }

    public void GotHit()
    {
        enemyHitSound.Play();

        if (isDead)
            return;

        gun.transform.parent = null;
        anim.enabled = false;
        isDead = true;
        for (int i = 0; i < bodies.Length; i++)
            bodies[i].isKinematic = false;

        if (isBoss)
        {
            master = GameObject.FindGameObjectWithTag("master");
            //master.GetComponent<MasterScript>().DoSlowmotion();
            master.GetComponent<MasterScript>().canContinue = true;
            StartCoroutine(WaitAndPrint(master));
        }
    }

    private IEnumerator WaitAndPrint(GameObject master)
    {
        yield return new WaitForSeconds(2f);
        master.GetComponent<MasterScript>().winPanel.SetActive(true);
    }
}
