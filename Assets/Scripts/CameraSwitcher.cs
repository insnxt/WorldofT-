using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstPersonCamera; // Первая камера (например, камера от первого лица)
    public Camera thirdPersonCamera; // Вторая камера (например, камера от третьего лица)
    private bool isFirstPersonActive = true; // Флаг, показывающий, активна ли первая камера

    void Start()
    {
        // В начале игры активируем только первую камеру
        firstPersonCamera.gameObject.SetActive(true);
        thirdPersonCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        // Проверяем нажатие кнопки LShift
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Если активна первая камера, то активируем вторую и деактивируем первую
            if (isFirstPersonActive)
            {
                firstPersonCamera.gameObject.SetActive(false);
                thirdPersonCamera.gameObject.SetActive(true);
                isFirstPersonActive = false;
            }
            // Если активна вторая камера, то активируем первую и деактивируем вторую
            else
            {
                firstPersonCamera.gameObject.SetActive(true);
                thirdPersonCamera.gameObject.SetActive(false);
                isFirstPersonActive = true;
            }
        }
    }
}
