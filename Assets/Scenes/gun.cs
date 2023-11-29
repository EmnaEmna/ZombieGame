using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    private Camera mainCamera;
    public int bulletDamage = 10; // Adjust the damage as needed.
    public ShakeDetector sc;
    public AudioSource audioData;

    void Start()
    {
        mainCamera = Camera.main; // Get a reference to the main camera.
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to your preferred input method.
        {
           // Shoot();
        }
    }

    public void Shoot()
    {
    if(sc.nbul>0){
            audioData.Play(1);
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Center of the viewport
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hit an object with an "EnemyHealth" script.
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                // Apply damage to the enemy.
                enemy.TakeDamage(bulletDamage);
            }

            // Spawn the bullet as before.
            Vector3 endPoint = hit.point;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 shootDirection = (endPoint - firePoint.position).normalized;
                rb.velocity = shootDirection * bulletSpeed;
            }

            Destroy(bullet, 2f); // Destroy the bullet after 2 seconds (you can adjust this).
        }
        }
    }
}