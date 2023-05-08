using UnityEngine;

public class PlateButton : MonoBehaviour
{
    private bool isCubeOnButton;
    private Vector3 statePosition = new Vector3(0, 0.5f, 0);
    private void OnTriggerEnter(Collider other)
    {
        PhysicalObject isObjcect = GetComponent<PhysicalObject>();
        if (isObjcect != null)
        {
            
        }
    }
}
