using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float hp = 100f; 
    [SerializeField] private float maxHp = 100f; 
    [SerializeField] private Image healthBar;
    [SerializeField] private ParticleSystem deathParticles; // Asigna el sistema de partículas desde el Inspector

    public void TakeDamageEnemy(float amount)
    {
        hp -= amount;
        hp = Mathf.Clamp(hp, 0f, maxHp);

        // Actualizar el fillAmount de la barra de vida
        if (healthBar != null)
        {
            healthBar.fillAmount = hp / maxHp;
        }

        if (hp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Activa las partículas de muerte si están asignadas
        if (deathParticles != null)
        {
            deathParticles.transform.parent = null; // Desvincula el sistema de partículas del enemigo
            deathParticles.Play(); // Inicia el sistema de partículas
            Destroy(deathParticles.gameObject, deathParticles.main.duration); // Destruye las partículas después de que terminen
        }

        Destroy(gameObject); // Destruye el GameObject del enemigo
    }
}
