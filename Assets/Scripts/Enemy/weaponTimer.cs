using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponTimer : MonoBehaviour
{
    public float WeaponLifeTime = 5f;

    public void Update()
    {
        Destroy(gameObject, WeaponLifeTime);
    }
}
