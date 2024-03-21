using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 120.0f;
    public GameObject[] leftwheels;
    public GameObject[] rightwheels;
    public float wheelRotationSpeed = 200.0f;

    public AudioClip idleAudioClip;
    public AudioClip movingAudioClip;

    private Rigidbody rb;
    private float moveInput;
    private float rotationInput;
    private AudioSource idleAudioSource;
    private AudioSource movingAudioSource;

    public float idleVolume = 0.5f; // Громкость для состояния покоя
    public float movingVolume = 0.5f; // Громкость для движения

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Add AudioSource components
        idleAudioSource = gameObject.AddComponent<AudioSource>();
        movingAudioSource = gameObject.AddComponent<AudioSource>();

        // Set audio clips for each AudioSource
        idleAudioSource.clip = idleAudioClip;
        movingAudioSource.clip = movingAudioClip;

        // Configure AudioSource parameters
        idleAudioSource.loop = true;
        movingAudioSource.loop = true;

        // Set the volume
        idleAudioSource.volume = idleVolume;
        movingAudioSource.volume = movingVolume;

        // Start playing the idle audio clip
        idleAudioSource.Play();

    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        RotateWheels(moveInput, rotationInput);

        // Switch between audio tracks based on tank movement
        if (moveInput != 0 && !movingAudioSource.isPlaying)
        {
            movingAudioSource.Play();
            idleAudioSource.Stop();
        }
        else if (moveInput == 0 && !idleAudioSource.isPlaying)
        {
            idleAudioSource.Play();
            movingAudioSource.Stop();
        }
        
    }

    void FixedUpdate()
    {
        MoveTankObj(moveInput);
        RotateTank(rotationInput);
    }

    void MoveTankObj(float input)
    {
        Vector3 moveDirection = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }

    void RotateTank(float input)
    {
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void RotateWheels(float moveInput, float rotationInput)
    {
        float wheelRotation = moveInput * wheelRotationSpeed * Time.deltaTime;
        foreach (GameObject wheel in leftwheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation - rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
        foreach (GameObject wheel in rightwheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation + rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }
}








//     using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TankMovement : MonoBehaviour
// {
//     public float moveSpeed = 5.0f;
//     public float rotationSpeed = 120.0f;
//     public GameObject[] leftwheels;
//     public GameObject[] rightwheels;

//     public float wheelRotationSpeed = 200.0f;

//     private Rigidbody rb;
//     private float moveInput;
//     private float rotationInput; // Объявляем переменную rotationInput

//     private AudioSource audioSource;
//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         audioSource = GetComponent<AudioSource>();
//     }

//     void Update()
//     {
//         moveInput = Input.GetAxis("Vertical");
//         rotationInput = Input.GetAxis("Horizontal"); // Присваиваем значение переменной rotationInput

//         RotateWheels(moveInput, rotationInput);
//     }

//     void FixedUpdate()
//     {
//         MoveTankObj(moveInput);
//         RotateTank(rotationInput);
//     }

//     void MoveTankObj(float input)
//     {
//         Vector3 moveDirection = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
//         rb.MovePosition(rb.position + moveDirection);
//     }

//     void RotateTank(float input)
//     {
//         float rotation = input * rotationSpeed * Time.fixedDeltaTime;
//         Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
//         rb.MoveRotation(rb.rotation * turnRotation);
//     }

//     void RotateWheels(float moveInput, float rotationInput)
//     {
//         float wheelRotation = moveInput * wheelRotationSpeed * Time.deltaTime;
//         foreach (GameObject wheel in leftwheels)
//         {
//             if (wheel != null)
//             {
//                 wheel.transform.Rotate(wheelRotation - rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
//             }
//         }
//         foreach (GameObject wheel in rightwheels)
//         {
//             if (wheel != null)
//             {
//                 wheel.transform.Rotate(wheelRotation + rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
//             }
//         }
//     }
// }
