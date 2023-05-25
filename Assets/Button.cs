using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    [SerializeField][Range(0f, 20f)] private float timerCount;

    [SerializeField] private bool isPushed;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            isPushed = true;
            foreach (var obj in objects)
            {
                obj.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isPushed = false;
        StartCoroutine(Timer(timerCount));
    }
    private IEnumerator Timer(float timer)
    {
        yield return new WaitForSeconds(timer);
        foreach (var obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
