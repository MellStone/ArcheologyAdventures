using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] [Range(0f, 20f)] private float timerCount;

    private bool isPushed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && !isPushed)
        {       
            isPushed = true;
            StopAllCoroutines();
            foreach (var obj in objects)
            {
                if(obj.activeSelf)
                    obj.SetActive(false);
                else 
                    obj.SetActive(true);
            }
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
        foreach (var obj in objects)
        {
            if (obj.activeSelf)
                obj.SetActive(false);
            else
                obj.SetActive(true);
        }
        isPushed = false;
        particles.Stop();
    }
}
