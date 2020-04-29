using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public GameObject[] weapons;
    public int currentWeapon = 0;

    public bool canSwap = true;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(canSwap)
        {
            int previousWeapon = currentWeapon;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (currentWeapon >= weapons.Length - 1)
                    currentWeapon = 0;
                else
                    currentWeapon++;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (currentWeapon <= 0)
                    currentWeapon = weapons.Length - 1;
                else
                    currentWeapon--;
            }

            if (previousWeapon != currentWeapon)
            {
                SelectWeapon();
            }
        }
    }

    void SelectWeapon()
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            if (currentWeapon == i)
                weapons[i].gameObject.SetActive(true);
            else
                weapons[i].gameObject.SetActive(false);
        }
        
    }
}
