using UnityEngine;

public class Peligro : MonoBehaviour
{
    public int daño = 10; 

    void OnTriggerEnter(Collider other)
    {
        VidaJugador vidaJugador = other.GetComponent<VidaJugador>();
        if (vidaJugador != null)
        {
            vidaJugador.RecibirDaño(daño);
        }
    }
}
