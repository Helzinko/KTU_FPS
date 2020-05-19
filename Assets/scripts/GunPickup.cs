using UnityEngine;

public class GunPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pistolPickup" && other.transform.parent == null)
        {
            Debug.Log("Picked: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
