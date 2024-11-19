using System.Collections; // Necesario para IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private string defeatSceneName = "Defeat"; // Nombre de la escena a cargar
    [SerializeField] private float timeNextScena = 2f;
    private PlayerManager playerManager;

    private void Start()
    {
        // Buscar el PlayerManager del jugador
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();

        if (playerManager == null)
        {
            Debug.LogError("No se encontró un PlayerManager en la escena.");
        }
    }

    private void Update()
    {
        // Verificar si el jugador ha muerto
        if (playerManager != null && !playerManager.IsAlive())
        {
            // Iniciar la transición a la escena de derrota
            StartCoroutine(LoadDefeatScene());
        }
    }

    private IEnumerator LoadDefeatScene()
    {
        // Esperar 3 segundos
        yield return new WaitForSeconds(timeNextScena);

        // Cargar la escena de derrota
        SceneManager.LoadScene(defeatSceneName);
    }
}
