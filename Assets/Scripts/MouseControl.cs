using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private bool isCursorFrozen = false;
    private CursorLockMode previousLockMode;
    private bool previousCursorVisibility;

    void Start()
    {
        // Сохраняем исходное состояние курсора
        previousLockMode = Cursor.lockState;
        previousCursorVisibility = Cursor.visible;
    }

    void Update()
    {
        // Проверяем нажатие кнопки для замораживания/размораживания курсора
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isCursorFrozen)
            {
                FreezeCursor();
            }
            else
            {
                UnfreezeCursor();
            }
        }
    }

    void FreezeCursor()
    {
        // Замораживаем курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCursorFrozen = true;
    }

    void UnfreezeCursor()
    {
        // Размораживаем курсор и возвращаем его в исходное состояние
        Cursor.lockState = previousLockMode;
        Cursor.visible = previousCursorVisibility;
        isCursorFrozen = false;
    }

    void OnDestroy()
    {
        // Возвращаем курсор в исходное состояние при уничтожении объекта
        Cursor.lockState = previousLockMode;
        Cursor.visible = previousCursorVisibility;
    }
}
