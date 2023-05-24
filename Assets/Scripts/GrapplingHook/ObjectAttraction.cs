using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAttraction : MonoBehaviour
{
    public Transform character; // Ссылка на персонажа
    public float attractionSpeed = 5f; // Скорость притягивания

    private bool attractObjects = false; // Флаг, указывающий, притягивать объекты или нет
    private Rigidbody rb; // Компонент Rigidbody объекта

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Клавиша, которую вы хотите использовать для активации/деактивации притягивания
        {
            attractObjects = !attractObjects; // Инвертируем флаг при каждом нажатии клавиши
        }
    }

    private void FixedUpdate()
    {
        if (attractObjects)
        {
            // Получаем направление к персонажу
            Vector3 direction = character.position - transform.position;
            direction.Normalize();

            // Притягиваем объект к персонажу с заданной скоростью
            rb.AddForce(direction * attractionSpeed);
        }
    }
}
