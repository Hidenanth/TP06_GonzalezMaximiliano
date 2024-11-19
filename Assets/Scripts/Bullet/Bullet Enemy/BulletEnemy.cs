using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 10f; // Velocidad de la bala
    [SerializeField] private float timeDestroy = 3f; // Tiempo de vida de la bala
    [SerializeField] private float rotationSpeed = 180f; // Velocidad de rotación en grados por segundo
    [SerializeField] private float damage = 25f; // Cantidad de daño que causa la bala

    void Start()
    {
        // Le damos una velocidad inicial en la dirección en la que está mirando
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = transform.right * speed; // Dispara hacia la dirección que está mirando
        }

        // Destruye la bala después de `timeDestroy` segundos
        Destroy(gameObject, timeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si colisiona con un enemigo
        if (other.CompareTag("Player"))
        {
            PlayerManager enemy = other.GetComponent<PlayerManager>();
            if (enemy != null)
            {
                enemy.TakeDamagePlayer(damage); // Llama al método TakeDamage en el enemigo
            }
            Destroy(gameObject); // Destruye la bala al colisionar con el enemigo
        }

        // Verificamos si colisiona con el suelo
        if (other.CompareTag("ground"))
        {
            Destroy(gameObject); // Destruye la bala al colisionar con el suelo
        }
    }

    void Update()
    {
        // Rota la bala alrededor del eje Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
