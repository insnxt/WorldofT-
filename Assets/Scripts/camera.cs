using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Camera mainCamera; // Ссылка на основную камеру
    public Camera secondCamera; // Ссылка на вторую камеру

    void Start()
    {
        // Включаем только основную камеру в начале игры
        mainCamera.gameObject.SetActive(true);
        secondCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        // Проверяем нажатие на клавишу для переключения камер
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Переключаем между камерами, выключая одну и включая другую
            mainCamera.gameObject.SetActive(!mainCamera.gameObject.activeSelf);
            secondCamera.gameObject.SetActive(!secondCamera.gameObject.activeSelf);
        }
    }
}
