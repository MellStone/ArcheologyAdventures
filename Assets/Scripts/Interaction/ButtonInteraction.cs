using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject cube; // ссылка на куб
    public GameObject button; // ссылка на кнопку

    private bool isCubeOnButton; // флаг, указывающий, находится ли куб на кнопке

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == cube)
        {
            isCubeOnButton = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == cube)
        {
            isCubeOnButton = false;
        }
    }

    void Update()
    {
        if (isCubeOnButton && Input.GetKeyDown(KeyCode.E))
        {
            // переместить куб на кнопку и отключить его физику
            cube.transform.position = button.transform.position + new Vector3(0, 0.5f, 0);
            cube.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if (!isCubeOnButton && Input.GetKeyDown(KeyCode.E))
        {
            // включить физику куба и переместить его обратно
            cube.GetComponent<Rigidbody>().isKinematic = false;
            cube.transform.position = transform.position + new Vector3(0, 1, 0);
        }
    }
}
