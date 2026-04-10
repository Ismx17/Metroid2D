using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;

    private Rigidbody2D fisica;

    private void Start() 
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.linearVelocity = new Vector2(entradaX * velocidad, fisica.linearVelocity.y);

        // Lógica para girar el sprite
        if (entradaX > 0) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (entradaX < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && TocarSuelo()) 
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
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