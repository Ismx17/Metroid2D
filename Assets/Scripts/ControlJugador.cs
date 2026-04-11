using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;

    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    private Animator animacion;

    private void Start() 
    {
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.linearVelocity = new Vector2(entradaX * velocidad, fisica.linearVelocity.y);
    }

    private void Update() 
    {
        // Logica de salto
        if (Input.GetKeyDown(KeyCode.Space) && TocarSuelo()) 
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        // Si va hacia la derecha flipX = true
        if (fisica.linearVelocity.x > 0.1f) 
        {
            sprite.flipX = false;
        }
        // Si va hacia la izquierda flipX = false y volteo
        else if (fisica.linearVelocity.x < -0.1f) 
        {
            sprite.flipX = true;
        }
        
        animarJugador();
    }

    private void animarJugador()
    {
        // Jugador saltando
        if (!TocarSuelo()) 
        animacion.Play("jugadorSaltando");
        //Jugador corriendo
        else if ((fisica.linearVelocity.x > 0.1f || fisica.linearVelocity.x < -0.1f) && fisica.linearVelocity.y == 0) 
        animacion.Play("jugadorCorriendo");
        // Jugador parado
        else if ((fisica.linearVelocity.x < 0.1f || fisica.linearVelocity.x > -0.1f) && fisica.linearVelocity.y == 0) 
        animacion.Play("jugadorParado");
    }

    private bool TocarSuelo() 
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return toca.collider != null;
    }

    public void FinJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}