using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnEnable : MonoBehaviour
{
    [SerializeField] float showingTime = 4f;
    private void OnEnable()
    {
        StartCoroutine(TimeToHide(showingTime));
    }
    IEnumerator TimeToHide(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
