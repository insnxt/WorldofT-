using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullethan : MonoBehaviour
{
    public float launchSpeed = 75.0f;
    public GameObject objectPrefab;
    private bool isReloading = false;

    public AudioClip idleAudioClip;
    private AudioSource fireSource;

    public float fireVolume = 0.5f; 

    // Start is called before the first frame update
    void Start()
    {
        fireSource = gameObject.AddComponent<AudioSource>();
        fireSource.clip = idleAudioClip;
        fireSource.volume = fireVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isReloading)
        {
            fireSource.Play();
            StartCoroutine(Reload());

            Spawnobject();
        }
    }


    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(1.5f); // Подождать 1.5 секунд
        isReloading = false;
    }

    void Spawnobject()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.identity;

        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = localXDirection * launchSpeed;

        GameObject newObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;

        // Запускаем корутину для удаления пули после некоторого времени
        StartCoroutine(DestroyBulletAfterTime(newObject));
    }

    IEnumerator DestroyBulletAfterTime(GameObject bullet)
    {
        yield return new WaitForSeconds(5.0f); // Удалить пулю после 5 секунд
        Destroy(bullet);
    }
}
















// using System.Collections;
// using UnityEngine;

// public class BulletHan : MonoBehaviour
// {
//     public float launchSpeed = 75.0f;
//     public GameObject bulletPrefab;
//     public Transform firePoint;
//     public float maxDistance = 100f; // Максимальное расстояние, на котором пуля будет уничтожена

//     private AudioSource fireSource;
//     public AudioClip idleAudioClip;
//     public float fireVolume = 0.5f; 
//     private bool isReloading = false;

//     private void Start()
//     {
//         fireSource = gameObject.AddComponent<AudioSource>();
//         fireSource.clip = idleAudioClip;
//         fireSource.volume = fireVolume;
//     }

//     private void Update()
//     {
//         if (Input.GetButtonDown("Fire1") && !isReloading)
//         {
//             fireSource.Play();
//             StartCoroutine(Reload());
//             Shoot();
//         }
//     }

//     private IEnumerator Reload()
//     {
//         isReloading = true;
//         yield return new WaitForSeconds(1.5f); // Подождать 1.5 секунды
//         isReloading = false;
//     }

//     private void Shoot()
//     {
//         RaycastHit hit;
//         if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, Mathf.Infinity))
//         {
//             Vector3 targetPosition = hit.point;

//             GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
//             Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

//             Vector3 direction = (targetPosition - firePoint.position).normalized;
//             bulletRigidbody.velocity = direction * launchSpeed;

//             StartCoroutine(DestroyBulletAfterDistance(newBullet));
//         }
//         else
//         {
//             Vector3 targetPosition = firePoint.position + firePoint.forward * maxDistance;

//             GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
//             Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

//             Vector3 direction = (targetPosition - firePoint.position).normalized;
//             bulletRigidbody.velocity = direction * launchSpeed;

//             StartCoroutine(DestroyBulletAfterDistance(newBullet));
//         }
//     }

//     private IEnumerator DestroyBulletAfterDistance(GameObject bullet)
//     {
//         yield return new WaitForSeconds(maxDistance / launchSpeed);
//         Destroy(bullet);
//     }
// }
