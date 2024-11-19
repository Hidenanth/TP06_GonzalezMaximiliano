using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena
using UnityEngine.UI; // Para manejar botones
using UnityEngine.Audio; // Para manejar AudioMixer

public class MenuManager : MonoBehaviour
{
    [Header("Menu Panels")]
    [SerializeField] private GameObject mainMenuPanel; // Panel principal del menú
    [SerializeField] private GameObject settingsPanel; // Panel del submenú de configuraciones
    [SerializeField] private GameObject soundSettingsPanel; // Panel de configuraciones de sonido
    [SerializeField] private GameObject creditsPanel; // Panel de créditos

    [Header("Button References")]
    [SerializeField] private Button playButton; // Botón para jugar
    [SerializeField] private Button settingsButton; // Botón para abrir configuraciones
    [SerializeField] private Button quitButton; // Botón para salir del juego
    [SerializeField] private Button soundButton; // Botón en el submenú de configuraciones
    [SerializeField] private Button creditsButton; // Botón de créditos
    [SerializeField] private Button backFromSettingsButton; // Botón para volver del menú de configuraciones
    [SerializeField] private Button backFromSoundButton; // Botón para volver del menú de sonido
    [SerializeField] private Button backFromCreditsButton; // Botón para volver del menú de créditos

    [Header("Sound Settings")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider fxVolumeSlider;
    [SerializeField] private Slider uxVolumeSlider;

    [SerializeField] private AudioMixer audioMixer; // AudioMixer para controlar el volumen

    private void Start()
    {
        // Asignar funciones a los botones principales
        playButton.onClick.AddListener(PlayGame);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);  // Aquí corregimos el botón de salir

        // Asignar funciones a los botones del submenú
        soundButton.onClick.AddListener(OpenSoundSettings);
        creditsButton.onClick.AddListener(OpenCredits);
        backFromSettingsButton.onClick.AddListener(BackToMainMenu);
        backFromSoundButton.onClick.AddListener(BackToSettingsMenu);
        backFromCreditsButton.onClick.AddListener(BackToSettingsMenu);

        // Inicializar los valores de los sliders
        InitializeSliders();

        // Iniciar en el menú principal
        ShowMainMenu();
    }

    // Función para iniciar el juego
    private void PlayGame()
    {
        SceneManager.LoadScene("Gameplay"); // Cambia a la escena de Gameplay
    }

    // Función para abrir el submenú de configuraciones
    private void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    // Función para salir del juego
    private void QuitGame()
    {
        Debug.Log("Quit Game"); // Mensaje en el editor

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Si estás en el editor
        #else
            Application.Quit(); // Cierra el juego en build
        #endif
    }

    // Función para abrir el menú de configuraciones de sonido
    private void OpenSoundSettings()
    {
        settingsPanel.SetActive(false);
        soundSettingsPanel.SetActive(true);
    }

    // Función para abrir los créditos
    private void OpenCredits()
    {
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    // Función para regresar al menú principal
    private void BackToMainMenu()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // Función para regresar al menú de configuraciones
    private void BackToSettingsMenu()
    {
        soundSettingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    // Mostrar el menú principal
    private void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        soundSettingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    // Inicializar valores de los sliders de sonido
    private void InitializeSliders()
    {
        float masterVolume, musicVolume, fxVolume, uxVolume;

        audioMixer.GetFloat("Master", out masterVolume);
        audioMixer.GetFloat("MusicVolume", out musicVolume);
        audioMixer.GetFloat("FXVolume", out fxVolume);
        audioMixer.GetFloat("UXVolume", out uxVolume);

        masterVolumeSlider.value = Mathf.Pow(10, masterVolume / 20);
        musicVolumeSlider.value = Mathf.Pow(10, musicVolume / 20);
        fxVolumeSlider.value = Mathf.Pow(10, fxVolume / 20);
        uxVolumeSlider.value = Mathf.Pow(10, uxVolume / 20);
    }

    // Métodos para ajustar los volúmenes
    private void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(value) * 20);
    }

    private void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    private void SetFXVolume(float value)
    {
        audioMixer.SetFloat("FXVolume", Mathf.Log10(value) * 20);
    }

    private void SetUXVolume(float value)
    {
        audioMixer.SetFloat("UXVolume", Mathf.Log10(value) * 20);
    }
}
