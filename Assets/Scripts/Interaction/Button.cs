using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private ParticleSystem particles;
    [SerializeField][Range(0f, 20f)] private float timerCount;

    private bool isPushed = false;
    private Coroutine timerCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (!isPushed)
        {
            isPushed = true;
            if (timerCoroutine != null)
            {
                StopCoroutine(timerCoroutine);
            }
            timerCoroutine = StartCoroutine(Timer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isPushed)
        {
            if (timerCoroutine == null)
            {
                timerCoroutine = StartCoroutine(Timer());
            }
        }
    }

    private IEnumerator Timer()
    {
        particles.gameObject.SetActive(true);
        particles.Play();

        ShowObject();

        yield return new WaitForSeconds(timerCount);

        ShowObject();

        particles.Stop();
        isPushed = false;
        timerCoroutine = null;
    }

    private void ShowObject()
    {
        foreach (var obj in objects)
        {
            bool mode = obj.activeSelf;
            obj.SetActive(!mode);
        }
    }
}
