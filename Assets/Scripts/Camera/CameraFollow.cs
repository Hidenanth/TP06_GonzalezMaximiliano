using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; // Transform del jugador
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10); // Desfase entre la cámara y el jugador
    [SerializeField] private float smoothSpeed = 0.125f; // Velocidad de suavizado

    void LateUpdate()
    {
        // Calculamos la posición deseada de la cámara con el offset
        Vector3 desiredPosition = playerTransform.position + offset;

        // Suavizamos la transición entre la posición actual y la deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizamos la posición de la cámara
        transform.position = smoothedPosition;
    }
}
