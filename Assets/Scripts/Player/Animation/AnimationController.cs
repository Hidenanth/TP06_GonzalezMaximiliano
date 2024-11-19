using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    // Estado del jugador
    private bool isRunning;
    private bool isJumping;
    private bool isIdle;
    private bool isAlive = true;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJumping = false; // Estamos en el suelo
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJumping = true; // No estamos en el suelo
        }
    }
    
    void Update()
    {
        if (!isAlive)
            return;

        UpdateAnimationState();
        HandleAnimations();
    }

    private void UpdateAnimationState()
    {
        isRunning = Input.GetAxis("Horizontal") != 0;
        isIdle = !isRunning && !isJumping;
    }

    private void HandleAnimations()
    {
        if (isJumping)
        {
            animator.SetBool("run", false);
            animator.SetBool("idle", false);
            animator.SetBool("jump", true);
        }
        else if (isRunning)
        {
            animator.SetBool("jump", false);
            animator.SetBool("idle", false);
            animator.SetBool("run", true);
        }
        else if (isIdle)
        {
            animator.SetBool("jump", false);
            animator.SetBool("run", false);
            animator.SetBool("idle", true);
        }
    }

    public void IsDie(bool die)
    {
        isAlive = die;

        animator.SetBool("jump", false);
        animator.SetBool("run", false);
        animator.SetBool("idle", false);
        animator.SetBool("die", true);
    }
}
