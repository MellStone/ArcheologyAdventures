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

    private void Update()
    {
        if (canFire && Input.GetMouseButtonDown(0))
        {
            FireArrow();
            StartCoroutine(ReloadCoroutine());
        }
    }

    private void OnEnable()
    {
        canFire = true;
    }

    private void FireArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
        arrowRigidbody.AddForce(arrowSpawnPoint.forward * 1000f);
    }

    private System.Collections.IEnumerator ReloadCoroutine()
    {
        canFire = false;
        yield return new WaitForSeconds(FireRate);
        canFire = true;
    }
}


