using System.Collections;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Prefab de la bala
    [SerializeField] private Transform firePoint; // Punto desde donde se dispara la bala
    [SerializeField] private float BulletSpeed = 10f;
     // Momento en que se puede disparar de nuevo

    public void FireBullet()
    {
        // Instancia la bala en la posición del firePoint y con la rotación del enemigo
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * BulletSpeed; // Ajusta la velocidad de la bala
        }
    }
}
