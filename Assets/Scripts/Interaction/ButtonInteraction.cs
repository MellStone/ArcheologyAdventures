using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject cube; // ������ �� ���
    public GameObject button; // ������ �� ������

    private bool isCubeOnButton; // ����, �����������, ��������� �� ��� �� ������

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
            // ����������� ��� �� ������ � ��������� ��� ������
            cube.transform.position = button.transform.position + new Vector3(0, 0.5f, 0);
            cube.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if (!isCubeOnButton && Input.GetKeyDown(KeyCode.E))
        {
            // �������� ������ ���� � ����������� ��� �������
            cube.GetComponent<Rigidbody>().isKinematic = false;
            cube.transform.position = transform.position + new Vector3(0, 1, 0);
        }
    }
}
