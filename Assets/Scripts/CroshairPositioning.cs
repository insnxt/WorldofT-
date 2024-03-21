using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPositioning : MonoBehaviour
{
    public Transform tankTurret; // Ссылка на трансформ дула танка
    public Transform crosshair; // Ссылка на трансформ прицела
    public LayerMask raycastMask; // Слои объектов, с которыми будет взаимодействовать луч
    public float maxDistance = 10f; // Максимальное расстояние, на котором может находиться прицел

    void Update()
    {
        // Создаем луч от дула танка в направлении прицела
        Ray ray = new Ray(tankTurret.position, tankTurret.forward);
        RaycastHit hit;

        // Проверяем, есть ли столкновение с объектом по лучу
        if (Physics.Raycast(ray, out hit, maxDistance, raycastMask))
        {
            // Если столкновение есть, перемещаем прицел ближе к точке столкновения
            crosshair.position = hit.point - tankTurret.forward * 0.1f; // Подвигаем прицел немного ближе к танку, чтобы он не пересекался с объектом
        }
        else
        {
            // Если столкновения нет, перемещаем прицел на максимальное расстояние
            crosshair.position = tankTurret.position + tankTurret.forward * maxDistance;
        }
    }
}
