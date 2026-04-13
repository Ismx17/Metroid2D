using UnityEngine;
using TMPro;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI tiempoTxt;
    public TextMeshProUGUI powerUpsTxt;

    public void setVidasTxt(int vidas) 
    {
        vidasTxt.text = "Vidas: " + vidas;
    }

   public void setTiempoTxt(int tiempo) 
    {
        int segundos = tiempo % 60;
        int minutos = tiempo / 60;
        tiempoTxt.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }

    public void setPowerUpsTxt(int cuantos) 
    {
        powerUpsTxt.text = "Objetos: " + cuantos;
    }
}