using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private string sceneName;
    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(sceneName);
        // Здесь можно добавить логику для обработки смерти игрока
        // Например, показать экран поражения, перезагрузить уровень и т. д.

        // В данном примере просто уничтожаем игровой объект игрока
        Destroy(gameObject);
    }
}
