namespace UI
{
    using UnityEngine;
    using UnityEngine.UI; // Asegúrate de importar UnityEngine.UI
    using UnityEngine.SceneManagement;

    public class VictoryUIManager : MonoBehaviour
    {
        [Header("Nombre de la escena Gameplay")]
        [SerializeField] private string gameplaySceneName = "Gameplay";

        [Header("Button References")]
        [SerializeField] private Button rePlay; // Referencia al botón Retry
        [SerializeField] private Button quit; // Referencia al botón Quit

        void Start()
        {
            // Verifica si los botones están asignados correctamente en el Inspector
            if (rePlay != null)
                rePlay.onClick.AddListener(OnrePlayButtonPressed);
            else
                Debug.LogWarning("El botón rePlay no está asignado.");

            if (quit != null)
                quit.onClick.AddListener(OnQuitButtonPressed);
            else
                Debug.LogWarning("El botón Quit no está asignado.");
        }

        private void OnrePlayButtonPressed()
        {
            // Verifica que el nombre de la escena esté correcto
            SceneManager.LoadScene(gameplaySceneName);
        }

        private void OnQuitButtonPressed()
        {
            Debug.Log("El juego se cerrará.");
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el Editor
            #else
            Application.Quit(); // Cierra el juego cuando se ejecuta fuera del Editor
            #endif
        }
    }
}
