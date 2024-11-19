using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar la siguiente escena
using TMPro; // Para usar TextMeshPro

public class DoorTrigger : MonoBehaviour
{
    [Header("Canvas y UI")]
    [SerializeField] private GameObject globalCanvas; // El canvas que se activa

    [Header("Escena Siguiente")]
    [SerializeField] private string nextSceneName; // Nombre de la escena siguiente

    private PlayerManager playerController; // Referencia al script del jugador (para obtener el puntaje)

    private void Start()
    {
        // Asegúrate de que el canvas esté desactivado al inicio
        if (globalCanvas != null)
            globalCanvas.SetActive(false);

        // Intentar obtener la referencia al script del jugador
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerController = player.GetComponent<PlayerManager>();
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con la etiqueta 'Player'.");
        }
    }

    // Este método se llama cuando otro collider entra en el área del trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entró es el jugador
        if (other.CompareTag("Player") && playerController != null)
        {
            // Mostrar el Canvas global
            if (globalCanvas != null)
                globalCanvas.SetActive(true);
        }
    }

    // Este método podría estar conectado a un botón en el Canvas para cambiar la escena
    public void OpenDoor()
    {
        if (playerController != null && playerController.GetScore() >= 10)
        {
            // Cambiar a la siguiente escena si el puntaje es 10 o más
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
