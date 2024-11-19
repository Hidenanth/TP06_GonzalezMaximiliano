using UnityEngine;

public class PlayerInteractive : MonoBehaviour
{
    private bool isNearInteractable = false; // Indica si el jugador está cerca de un objeto interactivo
    private GameObject currentInteractable; // El objeto interactivo cercano

    void Update()
    {
        if (isNearInteractable && Input.GetKeyDown(KeyCode.E))
        {
            // Ejecutar la interacción con el objeto actual
            InteractWithObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar si el jugador entra en un área interactiva
        if (other.CompareTag("Interactable"))
        {
            isNearInteractable = true;
            currentInteractable = other.gameObject;
            Debug.Log("Cerca de un objeto interactivo.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Detectar si el jugador sale del área interactiva
        if (other.CompareTag("Interactable"))
        {
            isNearInteractable = false;
            currentInteractable = null;
            Debug.Log("Saliste del área interactiva.");
        }
    }

    private void InteractWithObject()
    {
        if (currentInteractable != null)
        {
            // Llamar a un método de interacción en el objeto
            DoorTrigger door = currentInteractable.GetComponent<DoorTrigger>();
            if (door != null)
            {
                door.OpenDoor(); // Llamar al método para abrir la puerta
            }
            else
            {
                Debug.LogWarning("El objeto interactivo no tiene un componente DoorTrigger.");
            }
        }
    }
}
