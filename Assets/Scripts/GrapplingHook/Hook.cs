using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    public Transform gunTip;
    public float hookRange = 5f;
    public float hookSpeed = 10f;

    private bool isHooked = false;
    private Rigidbody hookedObject;
    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        ray = new Ray();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray.origin = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            ray.direction = Camera.main.transform.forward;

            if (Physics.Raycast(ray, out hit, hookRange))
            {
                hookedObject = hit.rigidbody;

                if (hookedObject && !isHooked)
                {
                    isHooked = true;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            ReleaseObject();
        }

        if (isHooked)
        {
            Vector3 hookDirection = transform.position - hookedObject.transform.position;
            hookedObject.AddForce(hookDirection * hookSpeed, ForceMode.Acceleration);
            UpdateHookLine();
        }
        else
        {
            ClearHookLine();
        }
    }

    private void ReleaseObject()
    {
        if (isHooked)
        {
            hookedObject = null;
            isHooked = false;
        }
    }

    private void UpdateHookLine()
    {
        lineRenderer.SetPosition(0, gunTip.position);
        lineRenderer.SetPosition(1, hookedObject.transform.position);
    }

    private void ClearHookLine()
    {
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }
}
