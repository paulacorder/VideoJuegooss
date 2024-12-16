using UnityEngine;

public class Peligro : MonoBehaviour
{
    public int da�o = 10; 

    void OnTriggerEnter(Collider other)
    {
        VidaJugador vidaJugador = other.GetComponent<VidaJugador>();
        if (vidaJugador != null)
        {
            vidaJugador.RecibirDa�o(da�o);
        }
    }
}
