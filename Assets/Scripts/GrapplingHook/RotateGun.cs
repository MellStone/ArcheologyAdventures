using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public GrapplingGun grappling;
    private Quaternion desiredrotation;
    private float rotationSpeed = 6f;
    
    private void FixedUpdate()
    {

        if (!grappling.IsGrappling())
        {
            desiredrotation = transform.parent.rotation;
        }
        else
        {
            desiredrotation = Quaternion.LookRotation(grappling.GetGrapplePoint() - transform.position);
        }

        transform.rotation = Quaternion.Lerp(a: transform.rotation, b: desiredrotation, t: Time.deltaTime * rotationSpeed);
    }
    



}       
    
