using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entró tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Cargar el siguiente nivel (asegúrate de que el nombre del nivel esté correcto)
            SceneManager.LoadScene("NombreDelSiguienteNivel");  // Reemplaza con el nombre del siguiente nivel
        }
    }

}
