using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
  
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float FireRate = 0.7f;
    public float ReloadTime = 1f;
    private bool canFire = true;

    

    public void FixedUpdate()
    {
        
        if (canFire && Input.GetMouseButtonDown(0))
        {
            FireArrow();
            StartCoroutine(Reload());
        }
     
    }
   
    void FireArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        arrow.GetComponent<Rigidbody>().AddForce(arrowSpawnPoint.forward * 1000f);
    }

   IEnumerator Reload()
    {
        canFire = false;
        yield return new WaitForSeconds(FireRate);
        canFire = true;
    }
}


