using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    public float bulletSpeed = 10f;
    public float shootCooldown = 0.5f;

    private float nextShootTime1 = 0f;
    private float nextShootTime2 = 0f;

    void Update()
    {
        // Disparo del jugador 1 con la tecla E
        if (Input.GetKey(KeyCode.E) && Time.time >= nextShootTime1)
        {
            ShootBullet(firePoint1);
            nextShootTime1 = Time.time + shootCooldown;
        }

        // Disparo del jugador 2 con la tecla Alpha0
        if (Input.GetKey(KeyCode.Keypad0) && Time.time >= nextShootTime2)
        {
            ShootBullet(firePoint2);
            nextShootTime2 = Time.time + shootCooldown;
        }
    }

    void ShootBullet(Transform firePoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.tag = "Bullet";
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;
        Destroy(bullet, 2f);
    }
}