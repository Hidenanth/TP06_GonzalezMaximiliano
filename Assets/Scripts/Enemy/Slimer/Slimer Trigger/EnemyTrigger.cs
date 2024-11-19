using System.Collections;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject; // Arrastra aquí el GameObject que tiene el script EnemyShot
    private EnemyShot enemyShot; // Declaración de la variable

    private bool playerInRange = false;
    private float nextFireTime = 0f;
    [SerializeField] private float fireDelay = 2f; // Tiempo de espera entre disparos

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene el componente EnemyShot del GameObject referenciado
        enemyShot = enemyObject.GetComponent<EnemyShot>();
        if (enemyShot == null)
        {
            Debug.LogError("El componente EnemyShot no está adjunto al GameObject referenciado.");
        }
    }

    // Método que se llama cuando el collider entra en contacto con otro collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // El jugador está dentro del rango
        }
    }

    // Método que se llama cuando el collider sale del contacto
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // El jugador sale del rango
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Time.time >= nextFireTime)
        {
            // Comprobamos si enemyShot no es null antes de llamar a FireBullet
            if (enemyShot != null)
            {
                enemyShot.FireBullet();
                nextFireTime = Time.time + fireDelay;
            }
        }
    }
}
