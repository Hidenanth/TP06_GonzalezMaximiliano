using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    [SerializeField] private float moveSpeed = 5f; // Velocidad de movimiento horizontal
    private bool isAlive = true;

    void Start()
    {
        // Asignamos el Rigidbody2D y el Animator del objeto al script
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isAlive)
            return;
            
        // Obtenemos el input horizontal del jugador
        float horizontalInput = Input.GetAxis("Horizontal");

        // Rotamos el `Player` según la dirección en la que se mueve
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); // Mirando a la izquierda
        }
        else if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // Mirando a la derecha
        }

        // Ajustamos la velocidad horizontal del Rigidbody2D directamente
        rigidBody2D.velocity = new Vector2(horizontalInput * moveSpeed, rigidBody2D.velocity.y);


    }
    public void DieMovement(bool die)
    {
        isAlive = die;
    }

}
