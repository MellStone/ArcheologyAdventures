using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private ParticleSystem particles;
    [SerializeField][Range(0f, 20f)] private float timerCount;

    private bool isPushed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && isPushed != true)
        {
            isPushed = true;
            StopAllCoroutines();
            ShowHideObject();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Timer(timerCount));
    }
    private IEnumerator Timer(float timer)
    {
        particles.gameObject.SetActive(true);
        particles.Play();
        yield return new WaitForSeconds(timer);
        ShowHideObject();
        isPushed = false;
        particles.Stop();
    }
    private void ShowHideObject()
    {
        foreach (var obj in objects)
        {
            bool mode = obj.activeSelf;
            obj.SetActive(!mode);
        }
    }
}