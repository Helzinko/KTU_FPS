using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Material black;
    private Material startingMaterial;

    public GameObject lamp;

    float minFlickerSpeed = 0.1f;
    float maxFlickerSpeed = 1.0f;

    bool canStart = true;

    private void Start()
    {
        startingMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (canStart)
        {
            float random = Random.Range(minFlickerSpeed, maxFlickerSpeed);
            StartCoroutine(Off(random));
            random = Random.Range(minFlickerSpeed, maxFlickerSpeed);
            StartCoroutine(On(random));
        }
    }

    IEnumerator Off(float random)
    {
        canStart = false;
        yield return new WaitForSeconds(random);
        lamp.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().material = black;
    }

    IEnumerator On(float random)
    {
        yield return new WaitForSeconds(random);
        lamp.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().material = startingMaterial;
        canStart = true;
    }
}
