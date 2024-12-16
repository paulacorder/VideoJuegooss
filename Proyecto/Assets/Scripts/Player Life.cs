using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima = 100; // Vida m�xima del jugador
    private int vidaActual;      // Vida actual del jugador

    public Slider barraDeVida;   // Referencia a la barra de vida en la UI

    void Start()
    {
        vidaActual = vidaMaxima; // Inicializa con la vida m�xima
        ActualizarBarraDeVida();
    }

    public void RecibirDa�o(int da�o)
    {
        vidaActual -= da�o;
        if (vidaActual < 0)
        {
            vidaActual = 0;
        }

        ActualizarBarraDeVida();

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    public void Curar(int cantidad)
    {
        vidaActual += cantidad;
        if (vidaActual > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }

        ActualizarBarraDeVida();
    }

    void ActualizarBarraDeVida()
    {
        if (barraDeVida != null)
        {
            barraDeVida.maxValue = vidaMaxima;
            barraDeVida.value = vidaActual;
        }
    }

    void Morir()
    {
        Debug.Log("El jugador ha muerto.");
       
    }

    public int GetVidaActual()
    {
        return vidaActual;
    }
}
