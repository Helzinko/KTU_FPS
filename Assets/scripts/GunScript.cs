using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float range = 100f;
    public float impactForce = 100f;
    public float fireRate = 2f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject fireLight;
    public GameObject lightPlace;

    private float nextFire;

    Animator m_Animator;

    // laser
    private WaitForSeconds shotDuration = new WaitForSeconds(0.5f);
    private LineRenderer laserLine;
    public GameObject bulletHole;

    private Rigidbody player;
    private float speed = 10;

    //private void Start()
    //{
    //    laserLine = GetComponent<LineRenderer>();
    //    m_Animator = gameObject.GetComponent<Animator>();
    //}



    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move();
        }
    }

    private void Move()
    {
        player.velocity = transform.right * speed;
    }



        //// Update is called once per frame
        //void Update()
        //{DDD
        //    if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        //    {
        //        nextFire = Time.time + fireRate;
        //        StartCoroutine(ShotEffect());
        //        Shoot();
        //    }
        //}

        //void Shoot()
        //{
        //    muzzleFlash.Play();
        //    m_Animator.SetTrigger("Shoot");

        //    GameObject fireLamp = Instantiate(fireLight, new Vector3(lightPlace.transform.position.x, lightPlace.transform.position.y, lightPlace.transform.position.z), Quaternion.identity);
        //    Destroy(fireLamp, 0.1f);

        //    RaycastHit hit;
        //    laserLine.SetPosition(0, bulletHole.transform.position);

        //    Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        //    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        //    {
        //        //target targetHit = hit.transform.GetComponent<target>();
        //        enemy enemeyHit = hit.transform.root.GetComponent<enemy>();

        //        laserLine.SetPosition(1, hit.point);

        //        if (enemeyHit != null)
        //        {
        //            enemeyHit.GotHit();

        //        }


        //        // hit effect
        //        GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //        Destroy(impactGo, 2f);

        //        if(hit.rigidbody != null)
        //        {
        //            if (hit.transform.root.tag == "enemy")
        //                hit.rigidbody.AddForce(-hit.normal * impactForce * 25);
        //            else hit.rigidbody.AddForce(-hit.normal * impactForce);
        //        }
        //    }
        //    else
        //    {
        //        laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * range));
        //    }
        //}

        private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

}
