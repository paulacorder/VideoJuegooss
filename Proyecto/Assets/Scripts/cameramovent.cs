using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovent : MonoBehaviour
{

    [Header("Player Settings")]
    public Transform target; // Arrastra aqu� el jugador desde el inspector

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0, 1, -10); // Ajuste inicial de la posici�n de la c�mara
    public float smoothSpeed = 0.125f; // Velocidad de seguimiento

    void LateUpdate()
    {
        // Verifica si el objetivo est� asignado
        if (target != null)
        {
            // Calcula la posici�n deseada de la c�mara
            Vector3 desiredPosition = target.position + offset;

            // Suaviza el movimiento de la c�mara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualiza la posici�n de la c�mara
            transform.position = smoothedPosition;
        }
        else
        {
            Debug.LogWarning("El objeto objetivo no est� asignado a la c�mara.");
        }
    }
}

