using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBettle : MonoBehaviour
{
    public float moveSpeed = 2f;  // Velocidad de movimiento
    public float moveRange = 3f;  // Distancia máxima de movimiento a izquierda y derecha
    private Vector2 startPosition;  // Posición inicial del enemigo

    // Start is called before the first frame update
    void Start()
    {
        // Guardar la posición inicial del enemigo
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento oscilante (de izquierda a derecha)
        float movement = Mathf.PingPong(Time.time * moveSpeed, moveRange);

        // Mover al enemigo en el eje X basado en el movimiento oscilante
        transform.position = new Vector2(startPosition.x + movement, transform.position.y);
    }

    // Método para manejar las colisiones con Daisy
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si Daisy está colisionando
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtén la posición relativa de Daisy
            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 enemyCenter = GetComponent<Collider2D>().bounds.center;

            // Si el punto de contacto está encima del enemigo, destruye al enemigo
            if (contactPoint.y > enemyCenter.y)
            {
                Destroy(gameObject); // Destruye al enemigo
            }
        }
    }
}

