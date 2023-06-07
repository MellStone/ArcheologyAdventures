using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float ArrowLifeTime = 5f;

    private void Update()
    {
        Destroy(gameObject, ArrowLifeTime);
    }
}
