using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public int maxHealth = 300;
    private int currentHealth;
    public bool shouldDestroyOnDeath = true; // Переменная, определяющая, будет ли объект уничтожен при смерти

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Дополнительные действия при уничтожении здания
        Debug.Log("Building destroyed!");
        if (shouldDestroyOnDeath)
        {
            Destroy(gameObject); // Уничтожаем объект здания при достижении нулевого здоровья, если shouldDestroyOnDeath == true
        }
    }
}

