using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    
    public Transform gunTip;
    
    public float hookRange = 5f; // Дальность действия крюка
    public float hookSpeed = 10f; // Скорость движения объекта при притягивании

    private bool isHooked = false; // Флаг, указывающий, находится ли объект на крюке
    private Rigidbody hookedObject; // Объект, находящийся на крюке
    private LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }


    void Update()
    {
        // Проверяем нажатие на левую кнопку мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Выпускаем луч из центра экрана
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hit;

            // Если луч попал в объект
            if (Physics.Raycast(ray, out hit, hookRange))
            {
                // Получаем Rigidbody объекта
                Rigidbody hitRigidbody = hit.collider.GetComponent<Rigidbody>();

                // Если объект имеет Rigidbody и ещё не находится на крюке
                if (hitRigidbody && !isHooked)
                {
                    // Захватываем объект
                    hookedObject = hitRigidbody;
                    isHooked = true;
                }
            }
        }

        // Проверяем нажатие на правую кнопку мыши
        if (Input.GetMouseButtonDown(1))
        {
            // Отпускаем объект
            ReleaseObject();
        }

        // Если объект на крюке
        if (isHooked)
        {
            // Вычисляем направление крюка к объекту
            Vector3 hookDirection = transform.position - hookedObject.transform.position;

            // Притягиваем объект
            hookedObject.AddForce(hookDirection * hookSpeed, ForceMode.Acceleration);
            
            
           DrawHookLine();
        }
        else
        {
            ClearHookLine();
        }
    }

   
    void ReleaseObject()
    {
        if (isHooked)
        {
           
            // Отпускаем объект
            hookedObject = null;
            isHooked = false;
        }
    }

    void DrawHookLine()
    {
        lr.positionCount = 2;
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, hookedObject.transform.position);
    }
    void ClearHookLine()
    {
        lr.positionCount = 0;
    }
}
