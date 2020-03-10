using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
            other.GetComponent<Player>().HittedByBullet();
        else Destroy(gameObject);
    }
}
