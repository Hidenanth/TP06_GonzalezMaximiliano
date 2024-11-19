using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f; // Velocidad de la bala
    [SerializeField] private float timeDestroy = 3f; // Tiempo de vida de la bala
    [SerializeField] private float damage = 25f; // Cantidad de daño que causa la bala

    void Start()
    {
        // Inicializamos el Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // Le damos una velocidad inicial en la dirección en la que está mirando
        if (rb != null)
        {
            rb.velocity = transform.right * speed * (transform.localScale.x > 0 ? 1 : -1);
        }

        // Destruye la bala después de `timeDestroy` segundos
        Destroy(gameObject, timeDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si colisiona con un enemigo
        if (other.CompareTag("enemy"))
        {
            EnemyManager enemy = other.GetComponent<EnemyManager>();
            if (enemy != null)
            {
                enemy.TakeDamageEnemy(damage); // Llama al método TakeDamage en el enemigo
            }
            Destroy(gameObject); // Destruye la bala al colisionar con el enemigo
        }

        // Verificamos si colisiona con el suelo
        if (other.CompareTag("ground"))
        {
            Destroy(gameObject); // Destruye la bala al colisionar con el suelo
        }
    }
}
