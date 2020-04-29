using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float nextReload;

    Animator m_Animator;

    // laser
    private WaitForSeconds shotDuration = new WaitForSeconds(0.5f);
    private LineRenderer laserLine;
    public GameObject bulletHole;

    private Rigidbody player;
    private float speed = 10;

    public int bulletCount = 6;
    public float realoadTime = 0.5f;

    public Text bulletCountText;

    public GameObject weaponHolder;

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        m_Animator = gameObject.GetComponent<Animator>();
    }

    public bool canSwap = true;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextReload && Time.time > nextFire)
            weaponHolder.GetComponent<WeaponSwap>().canSwap = true;

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && bulletCount > 0 && Time.time > nextReload)
        {
            weaponHolder.GetComponent<WeaponSwap>().canSwap = false;
            bulletCount--;
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Shoot();
            bulletCountText.text = bulletCount.ToString();
        }

        if (Input.GetKeyDown(KeyCode.R) && Time.time > nextReload)
        {
            weaponHolder.GetComponent<WeaponSwap>().canSwap = false;
            Reload();
            nextReload = Time.time + realoadTime;
            bulletCountText.text = bulletCount.ToString();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        m_Animator.SetTrigger("Shoot");

        GameObject fireLamp = Instantiate(fireLight, new Vector3(lightPlace.transform.position.x, lightPlace.transform.position.y, lightPlace.transform.position.z), Quaternion.identity);
        Destroy(fireLamp, 0.1f);

        RaycastHit hit;
        laserLine.SetPosition(0, bulletHole.transform.position);

        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //target targetHit = hit.transform.GetComponent<target>();
            enemy enemeyHit = hit.transform.root.GetComponent<enemy>();

            laserLine.SetPosition(1, hit.point);

            if (enemeyHit != null)
            {
                enemeyHit.GotHit();

            }


            // hit effect
            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);

            if (hit.rigidbody != null)
            {
                if (hit.transform.root.tag == "enemy")
                    hit.rigidbody.AddForce(-hit.normal * impactForce * 25);
                else hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * range));
        }
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
    
    private void Reload()
    {
        bulletCount = 6;
        m_Animator.SetTrigger("Reload");
    }
}
