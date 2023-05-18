using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappling : MonoBehaviour
{
    [Header("references")]
    private PlayerMovement pm;
    public Transform cam;
    public Transform GunTip;
    public LayerMask WhatIsGrappleable;
    public LineRenderer Lr;

    [Header("Grappling")]
    public float maxGrapplingDistance;
    public float grapplingDelayTime;
    private Vector3 grapplePoint;

    [Header("Cooldown")]
    public float GrapplingCd;
    private float grapplingCdTimer;

    [Header("input")]
    public KeyCode grappleKey = KeyCode.Mouse1;
    private bool Grappling;


    private void Update()
    {
        if (Input.GetKeyDown(grappleKey)) StartGrapple();

        if (grapplingCdTimer > 0)
            grapplingCdTimer -= Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (Grappling)
            Lr.SetPosition(0, GunTip.position);
    }


    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    
    private void StartGrapple()
    {
        if (grapplingCdTimer > 0) return;

        Grappling = true;

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrapplingDistance, WhatIsGrappleable))
        {
            grapplePoint = hit.point;

            Invoke(nameof(ExecuteGrapple), grapplingDelayTime);
        }
        else
        {
            grapplePoint = cam.position + cam.forward * maxGrapplingDistance;

            Invoke(nameof(StopGrapple), grapplingDelayTime);
        }
        Lr.enabled = true;
        Lr.SetPosition(1, grapplePoint);
    }
    
    private void ExecuteGrapple()
    {

    }
    
    private void StopGrapple()
    {
        Grappling = false;

        grapplingCdTimer = GrapplingCd;

        Lr.enabled = false;
    }
}
