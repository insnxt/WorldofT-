using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public Transform tankTurret; // Ссылка на трансформ дула танка

    void Update()
    {
        // Получаем направление, куда смотрит дуло танка
        Vector3 direction = tankTurret.forward;

        // Поворачиваем прицел в направлении дула танка
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
