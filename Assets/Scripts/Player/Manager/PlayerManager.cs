using UnityEngine;
using UnityEngine.UI; 
using TMPro; // Añadido para usar TextMeshPro

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float hp = 100f; // HP inicial del jugador
    [SerializeField] private Image healthBarImage; 
    [SerializeField] private TextMeshProUGUI scoreText; // Asigna el TextMeshPro desde el inspector
    private float maxHp;
    private int score = 0;

    private AnimationController animationController;
    private BoxCollider2D boxCollider2D;
    private Jump jump;
    private Shot shot;
    private Movement movement;
    private Rigidbody2D rb; 

    private bool isAlive = true; 

    private void Start()
    {
        maxHp = hp; 
        animationController = GetComponent<AnimationController>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jump>();
        shot = GetComponent<Shot>();
        movement = GetComponent<Movement>();

        UpdateScoreText(); // Inicializa el texto del puntaje
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Tramp"))
        {
            Die();
        }
    }

    public void TakeDamagePlayer(float amount)
    {
        if (!isAlive) return;

        hp -= amount;
        hp = Mathf.Clamp(hp, 0, maxHp);
        UpdateHealthBar();

        if (hp <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = hp / maxHp;
        }
        else
        {
            Debug.LogWarning("healthBarImage no está asignada en el inspector.");
        }
    }

    private void Die()
    {
        isAlive = false;

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
        
        jump.DieJump(isAlive);
        shot.DieShot(isAlive);
        movement.DieMovement(isAlive);

        hp = 0;
        UpdateHealthBar();

        jump.JumpingDie();
        boxCollider2D.isTrigger = true;

        if (animationController != null)
        {
            animationController.IsDie(isAlive);
        }
        else
        {
            Debug.LogWarning("AnimationController no está asignado.");
        }
    }

    private void Update() 
    {
        if (!isAlive)
            return;
    }

    public void UpdateScore(int collectible)
    {
        score += collectible;
        UpdateScoreText(); // Actualiza el texto del puntaje
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogWarning("scoreText no está asignado en el inspector.");
        }
    }
    
    public bool IsAlive()
    {
        return isAlive;
    }

    public int GetScore()
    {
        return score;
    }

}
