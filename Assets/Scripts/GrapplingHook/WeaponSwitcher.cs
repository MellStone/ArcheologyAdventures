using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;
    public bool isBowOpen = false;
    private void Start()
    {
        SwitchWeapon(currentWeaponIndex);
    }

    private void Update()
    {
        int previousWeaponIndex = currentWeaponIndex;

        if (Input.GetKeyDown(KeyCode.Alpha1) && currentWeaponIndex != 0)
        {
            currentWeaponIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && currentWeaponIndex != 1 && isBowOpen)
        {
            currentWeaponIndex = 1;
        }
        

        if (currentWeaponIndex != previousWeaponIndex)
        {
            SwitchWeapon(currentWeaponIndex);
        }
    }
    public void BowIsOpen()
    {
        isBowOpen = true;
    }
    private void SwitchWeapon(int weaponIndex)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            bool isActive = (i == weaponIndex);
            if (weapons[i].activeSelf != isActive)
            {
                weapons[i].SetActive(isActive);
            }
        }
    }
}
