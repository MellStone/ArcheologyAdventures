using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPos : MonoBehaviour
{
    public Transform position;

    private void Update()
    {
        transform.position = transform.position;
    }
}
