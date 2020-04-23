using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBody : MonoBehaviour
{
    GameObject player;
    GameObject parent;

    public float seeDistance = 30;

    public float bulletSpeed = 100;

    public GameObject bullet;
    public GameObject bulletHole;

    float fireRate = 1f;
    float nextFire;

    bool sawPlayer = false;

    public ParticleSystem muzzleFlash;
    public GameObject lightPlace;
    public GameObject fireLight;

    void Start()
    {
        parent = transform.parent.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!parent.GetComponent<enemy>().isDead)
        {
            //if (sawPlayer)
                //GetComponent<NavMeshAgent>().destination = player.transform.position;

            if (Vector3.Distance(transform.position, player.transform.position) < seeDistance)
            {
                Vector3 lookAtPosition = player.transform.position;
                lookAtPosition.y = transform.position.y;
                transform.LookAt(lookAtPosition);
            }
        }

        //if (parent.GetComponent<enemy>().isDead)
           // Destroy(GetComponent<NavMeshAgent>());



        if (!parent.GetComponent<enemy>().isDead && Time.time > nextFire)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < seeDistance)
            {
                Vector3 fwd = transform.TransformDirection(Vector3.forward);
                Debug.DrawRay(transform.position, fwd * seeDistance, Color.green);

                RaycastHit objectHit;

                if (Physics.Raycast(transform.position, fwd, out objectHit, seeDistance))
                {
                    if (objectHit.transform.tag == "Player")
                    {
                        //effects
                        muzzleFlash.Play();
                        GameObject fireLamp = Instantiate(fireLight, new Vector3(lightPlace.transform.position.x, lightPlace.transform.position.y, lightPlace.transform.position.z), Quaternion.identity);
                        Destroy(fireLamp, 0.1f);
                        //
                        sawPlayer = true;
                        nextFire = Time.time + fireRate;
                        GameObject newProjectile = Instantiate(bullet, bulletHole.transform.position, transform.rotation);
                        newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
                        Destroy(newProjectile, 2f);
                    }

                }
            }
        }
    }
}
