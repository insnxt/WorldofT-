using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 30.0f;
    public float elevationSpeed = 20.0f; // Скорость подъема/опускания башни
    public Transform turretTransform;
    public Transform towerTransform;
    public Transform aimTransform;
    private float lastFireTime;
    private float turretElevation = 0.0f;

    void Update()
    {
        float turretRotationInput = Input.GetAxis("Mouse X");
        float towerRotationInput = Input.GetAxis("Mouse Y");
        RotateTurret(turretRotationInput);
        ElevateTower(towerRotationInput);
    }

    void RotateTurret(float input)
    {
        turretTransform.Rotate(Vector3.up * input * rotationSpeed * Time.deltaTime);
    }

    void ElevateTower(float input)
    {
        turretElevation -= input * elevationSpeed * Time.deltaTime;
        turretElevation = Mathf.Clamp(turretElevation, -20.0f, 20.0f); // Ограничиваем угол наклона от -20 до 20 градусов
        towerTransform.localRotation = Quaternion.Euler(turretElevation, 0.0f, 0.0f);
    }

}
