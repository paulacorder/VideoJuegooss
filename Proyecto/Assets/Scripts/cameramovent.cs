using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovent : MonoBehaviour
{

    [Header("Player Settings")]
    public Transform target; // Arrastra aquí el jugador desde el inspector

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 1, -10); // Ajuste inicial de la posición de la cámara
    public float smoothSpeed = 0.125f; // Velocidad de seguimiento

    void LateUpdate()
    {
        // Verifica si el objetivo está asignado
        if (target != null)
        {
            // Calcula la posición deseada de la cámara
            Vector3 desiredPosition = target.position + offset;

            // Suaviza el movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualiza la posición de la cámara
            transform.position = smoothedPosition;
        }
        else
        {
            Debug.LogWarning("El objeto objetivo no está asignado a la cámara.");
        }
    }
}

