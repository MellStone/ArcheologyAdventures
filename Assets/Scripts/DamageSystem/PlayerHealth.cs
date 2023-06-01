using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье игрока
    private int currentHealth; // Текущее здоровье игрока

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Проверяем, не упала ли здоровье игрока ниже 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Здесь можно добавить логику для обработки смерти игрока
        // Например, показать экран поражения, перезагрузить уровень и т. д.

        // В данном примере просто уничтожаем игровой объект игрока
        Destroy(gameObject);
    }
}
