using UnityEngine;

public class PlateButton : MonoBehaviour
{
    public GameObject cube; // ссылка на куб
    public GameObject button; // ссылка на кнопку

    private bool isCubeOnButton;

    void Start()
    {
        isCubeOnButton = false;
    }

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
        if (isCubeOnButton)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cube.transform.position = transform.position + Vector3.up * 0.5f; // переместить куб на расстояние 0.5 единицы вверх от кнопки
                cube.GetComponent<Rigidbody>().isKinematic = false; // включить физику куба
                isCubeOnButton = false;
            }
        }
        else
        {
            // проверить, находится ли куб в тригерной зоне кнопки
            isCubeOnButton = Physics.CheckBox(transform.position, new Vector3(0.5f, 0.5f, 0.5f), cube.transform.rotation, LayerMask.GetMask("Cube"));
        }
    }

}
