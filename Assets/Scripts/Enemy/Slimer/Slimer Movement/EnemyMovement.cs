using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private Vector3 startPosition; // Posición inicial del enemigo
    private bool movingRight = true; // Controla la dirección de movimiento
    [SerializeField] private float moveSpeed = 2f; // Velocidad de movimiento del enemigo
    [SerializeField] private float moveDistance = 3f; // Distancia que el enemigo se moverá hacia la derecha e izquierda

    void Start()
    {
        animator = GetComponent<Animator>();
        // Guardamos la posición inicial
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculamos la nueva posición en función del tiempo
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, 180, 0); // Mirando a la izquierda
            
            // Comprobamos si el enemigo ha alcanzado la distancia máxima
            if (transform.position.x >= startPosition.x + moveDistance)
            {
                movingRight = false; // Cambiamos la dirección
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            transform.rotation = Quaternion.Euler(0, 0, 0); // Mirando a la derecha

            // Comprobamos si el enemigo ha regresado a la posición inicial
            if (transform.position.x <= startPosition.x - moveDistance)
            {
                movingRight = true; // Cambiamos la dirección
            }
        }
    }
}
