using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
    
        if (sceneName != null)
            SceneManager.LoadScene(sceneName); 

    }
}
