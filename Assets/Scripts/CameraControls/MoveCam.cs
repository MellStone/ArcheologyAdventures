using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform cameraPosition;


    private void FixedUpdate()
    {
        transform.position = cameraPosition.position;
    }
}
