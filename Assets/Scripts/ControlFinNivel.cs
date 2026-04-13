using UnityEngine;
using TMPro;
public class ControlFinNivel : MonoBehaviour
{
    public TextMeshProUGUI mensajeFinalTexto;
    private ControlDatosJuego datosJuego;
    private void Start()
    {
        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();        
        string mensajeFinal = (datosJuego.Ganado) ? "HA GANADO!!" : "HA PERDIDO";

        if(datosJuego.Ganado) 
        {
            mensajeFinal += " Puntuación: " + datosJuego.Puntuacion;
        }
        mensajeFinalTexto.text = mensajeFinal;
    }
}