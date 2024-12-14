using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entr� tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Cargar el siguiente nivel (aseg�rate de que el nombre del nivel est� correcto)
            SceneManager.LoadScene("NombreDelSiguienteNivel");  // Reemplaza con el nombre del siguiente nivel
        }
    }

}
