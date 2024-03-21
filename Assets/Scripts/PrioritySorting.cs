using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrioritySorting : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Получаем компонент SpriteRenderer объекта
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Проверяем, что у объекта есть компонент SpriteRenderer
        if (spriteRenderer == null)
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }

    void Update()
    {
        // Назначаем наивысший порядок сортировки объекту
        spriteRenderer.sortingOrder = GetMaxSortingOrder() + 1;
    }

    // Получаем максимальный порядок сортировки среди всех объектов на сцене
    private int GetMaxSortingOrder()
    {
        int maxSortingOrder = int.MinValue;

        // Находим все объекты с компонентом SpriteRenderer в сцене
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();
        foreach (SpriteRenderer renderer in renderers)
        {
            // Обновляем максимальный порядок сортировки
            if (renderer.sortingOrder > maxSortingOrder)
            {
                maxSortingOrder = renderer.sortingOrder;
            }
        }

        return maxSortingOrder;
    }
}
