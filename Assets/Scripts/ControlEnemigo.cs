using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
   public float velocidad;
   public Vector3 posicionFin;

   private Vector3 posicionInicio;
   private bool moviendoAFin;

   void Start() 
   {
    posicionInicio = transform.position;
    moviendoAFin = true;
   }

   void Update() 
    {
        MoverEnemigo();
    }

    private void MoverEnemigo() 
    {
        // Calcular la posicion de destino
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;

        // Mover al enemigo
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        // Cambio de direccion
        if (transform.position == posicionFin) moviendoAFin = false;
        if (transform.position == posicionInicio) moviendoAFin = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        // Si el objeto que ha colisionado con el enemigo es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ControlJugador>().QuitarVida();
        }
    }
}