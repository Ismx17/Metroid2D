using UnityEngine;

public class ControlDatosJuego : MonoBehaviour
{
    private int puntuacion;
    private bool ganado;

    public int Puntuacion { get => puntuacion; set => puntuacion = value; }
    public bool Ganado { get => ganado; set => ganado = value; } 

    private void Awake()
    {
        int numInstancias = Object.FindObjectsByType<ControlDatosJuego>(FindObjectsSortMode.None).Length;

        if(numInstancias > 1) 
        {
            Destroy(this.gameObject);
        }
        else 
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}