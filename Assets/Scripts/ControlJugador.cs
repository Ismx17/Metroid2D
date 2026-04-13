using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public int fuerzaSalto;
    public int numVidas;
    public int tiempoNivel;
    public Canvas canvas; 

    public int puntuacion;

    private Rigidbody2D fisica;
    private SpriteRenderer sprite;
    private Animator animacion;
    private bool vulnerable;
    private float tiempoInicio;
    private int tiempoEmpleado;
    private ControlHUD hud;

    private ControlDatosJuego datosJuego;

    private void Start() 
    {
        tiempoInicio = Time.time;
        vulnerable = true;
        fisica = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacion = GetComponent<Animator>();
        hud = canvas.GetComponent<ControlHUD>();
        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
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

        hud.setPowerUpsTxt(GameObject.FindGameObjectsWithTag("PowerUp").Length);
        if (GameObject.FindGameObjectsWithTag("PowerUp").Length == 0) 
        {
            GanarJuego();
        }

        // Actualiza tiempo empleado
        tiempoEmpleado = (int)(Time.time - tiempoInicio);
        hud.setTiempoTxt(tiempoNivel - tiempoEmpleado);

        // Comprueba si hemos consumido el tiempo del nivel
        if(tiempoEmpleado >= tiempoNivel) 
        {
            Debug.Log("Tiempo Agotado");
            FinJuego();
        }
    }

    private void GanarJuego() 
    {
        puntuacion = (numVidas * 100) + (tiempoNivel - tiempoEmpleado);
        datosJuego.Puntuacion = puntuacion;
        datosJuego.Ganado = true;
        SceneManager.LoadScene("FinNivel");
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
        datosJuego.Ganado = false;
        SceneManager.LoadScene("FinNivel");
    }

    public void IncrementarPuntos(int cantidad) 
    {
        puntuacion += cantidad;
    }

    public void QuitarVida()
    {
        if(vulnerable) 
        {
            numVidas--;
            hud.setVidasTxt(numVidas);
            if(numVidas == 0) 
            {
             FinJuego();
            }
            Invoke("HacerVulnerable", 1f);
            sprite.color = Color.red;
        }
    }

    private void HacerVulnerable()
    {
        vulnerable = true;
        sprite.color = Color.white;
    }
}