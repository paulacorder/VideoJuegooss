using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DaisyMovement : MonoBehaviour

{
    public float moveSpeed = 5f;      // Velocidad de movimiento
    public float jumpForce = 10f;     // Fuerza del salto
    private int jumpCount = 0;        // Contador de saltos
    private int maxJumps = 2;         // Máximo número de saltos permitidos
    public float bounceForce = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Cambiar dirección del sprite según el movimiento
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++; // Incrementa el contador de saltos
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Restablece el contador de saltos al tocar cualquier superficie
        jumpCount = 0;

        if (collision.gameObject.CompareTag("enemy"))
        {
            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 playerCenter = GetComponent<Collider2D>().bounds.center;

            // Verifica si Daisy está cayendo sobre el enemigo (contacto desde arriba)
            if (contactPoint.y > playerCenter.y)
            {
                // Aplica fuerza de rebote
                rb.velocity = new Vector2(rb.velocity.x, bounceForce);
                Destroy(collision.gameObject); // Elimina el enemigo al ser tocado
            }
        }
    }
}



