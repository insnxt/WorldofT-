using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingCollision : MonoBehaviour
{
    public int playerDamage = 50; // Урон, который игрок наносит зданию
    public int buildingDamage = 100; // Урон, который здание наносит игроку
    public PlayerHealth playerHealth; // Ссылка на скрипт здоровья игрока
    public BuildingHealth buildingHealth; // Ссылка на скрипт здоровья здания

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Building"))
        {
            // Если произошло столкновение с зданием, отнимаем HP у игрока и у здания
            playerHealth.TakeDamage(buildingDamage);
            buildingHealth.TakeDamage(playerDamage * 2); // У здания отнимаем в два раза больше HP
        }
    }
}
