using UnityEngine;

public class CrosshairPlacement : MonoBehaviour
{
    public Transform tankTurret; // Ссылка на трансформ дула танка
    public Transform crosshair; // Ссылка на трансформ прицела
    public float maxDistance = 100f; // Максимальное расстояние, на котором может находиться прицел
    public float offset = 0.8f; // Отступ при смещении прицела
    public GameObject blockedObject; // Объект, который нужно заблокировать
    public string[] ignoredObjectNames; // Массив названий объектов, которые нужно игнорировать
    public Color normalColor = Color.white; // Нормальный цвет прицела
    public Color distantColor = Color.gray; // Цвет прицела при большом расстоянии
    public float colorChangeDistance = 30f; // Расстояние, на котором происходит смена цвета
    public float colorChangeTransitionSpeed = 5f; // Скорость перехода цвета

    private Color targetColor; // Целевой цвет прицела

    void Start()
    {
        // Устанавливаем начальный цвет прицела
        crosshair.GetComponent<Renderer>().material.color = normalColor;
        targetColor = normalColor;
    }

    void Update()
    {
        // Создаем луч от дула танка в направлении прицела
        Ray ray = new Ray(tankTurret.position, tankTurret.forward);
        RaycastHit hit;

        // Проверяем, есть ли столкновение с объектом по лучу
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            // Проверяем, является ли столкнувшийся объект блокируемым или игнорируемым
            if (hit.collider.gameObject == blockedObject || IsIgnoredObject(hit.collider.gameObject))
            {
                return; // Если да, игнорируем его и пропускаем дальнейшие действия
            }

            // Если столкновение есть, перемещаем прицел ближе к точке столкновения
            crosshair.position = hit.point - tankTurret.forward * offset; // Подвигаем прицел немного ближе к танку, чтобы он не пересекался с объектом

            // Проверяем, находится ли прицел на достаточно большом расстоянии, чтобы сменить цвет
            if (hit.distance > colorChangeDistance)
            {
                targetColor = distantColor;
            }
            else
            {
                targetColor = normalColor;
            }
        }
        else
        {
            // Если столкновения нет, перемещаем прицел на максимальное расстояние
            crosshair.position = tankTurret.position + tankTurret.forward * maxDistance;

            // Возвращаем нормальный цвет прицела
            targetColor = normalColor;
        }

        // Плавно меняем цвет прицела
        crosshair.GetComponent<Renderer>().material.color = Color.Lerp(crosshair.GetComponent<Renderer>().material.color, targetColor, colorChangeTransitionSpeed * Time.deltaTime);
    }

    // Функция для проверки, является ли объект игнорируемым
    private bool IsIgnoredObject(GameObject obj)
    {
        foreach (string ignoredObjectName in ignoredObjectNames)
        {
            if (obj.name.Contains(ignoredObjectName))
            {
                return true;
            }
        }
        return false;
    }
}
