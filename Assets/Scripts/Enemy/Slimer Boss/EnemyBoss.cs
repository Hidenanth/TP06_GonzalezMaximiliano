using UnityEngine;

public class EnemyBoss: MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
