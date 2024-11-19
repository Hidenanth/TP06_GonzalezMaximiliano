using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    [SerializeField] private float jumpForce = 5f; // Fuerza del salto
    private bool isGrounded; // Si el personaje está en el suelo
    private bool isAlive = true;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si estamos colisionando con un objeto que tiene el tag "ground"
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true; // Estamos en el suelo
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Verificamos si dejamos de colisionar con el objeto que tiene el tag "ground"
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false; // No estamos en el suelo
        }
    }

    void Update()
    {
        if (!isAlive)
            return;
            
        Jumping(); // Llama al método Jumping en cada frame
    }

    private void Jumping()
    {
        // Input de salto 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Aplicamos una fuerza vertical para hacer que el personaje salte
            rigidBody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void JumpingDie()
    {
        rigidBody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    public void DieJump(bool die)
    {
        isAlive = die;
    }
}
