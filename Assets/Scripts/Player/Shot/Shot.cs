using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Prefab de la bala
    [SerializeField] private float bulletSpeed = 10f; // Velocidad de la bala
    [SerializeField] private Transform firePoint; // Punto desde donde se dispara la bala
    [SerializeField] private float fireDelay = 1f; // Tiempo de espera entre disparos
    private bool isAlive = true;
    

    private float nextFireTime = 0f; // Momento en el que se puede disparar de nuevo

    void Update()
    {
        if (!isAlive)
            return;
            
        // Comprueba si se hace clic izquierdo y si ha pasado el tiempo suficiente desde el último disparo
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            FireBullet();
            // Actualiza el tiempo para el próximo disparo
            nextFireTime = Time.time + fireDelay;
        }
    }

    void FireBullet()
    {
        // Instancia la bala en la posición del firePoint y con la rotación del jugador
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Agrega velocidad a la bala en la dirección en la que el jugador está mirando
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * bulletSpeed * (transform.localScale.x > 0 ? 1 : -1);
        }
    }
    
    public void DieShot(bool die)
    {
        isAlive = die;
    }
}
