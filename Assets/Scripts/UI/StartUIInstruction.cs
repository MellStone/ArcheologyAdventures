using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIInstruction : MonoBehaviour
{
    [SerializeField] GameObject[] ui;
    [SerializeField] float secondsToNextUI;
    private bool isOn = false;

    void Update()
    {
        if (!isOn) 
        {
            if (Input.anyKey)
            {
                isOn = true;
                StartCoroutine(ShowUI());
            }
        }
    }
    IEnumerator ShowUI()
    {
        foreach (GameObject go in ui)
        {
            go.SetActive(true);
            yield return new WaitForSeconds(secondsToNextUI);
        }
    }

}
