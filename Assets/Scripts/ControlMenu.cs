using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public void OnBotonJugar() 
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void OnBotonCreditos() 
    {
        SceneManager.LoadScene("Creditos");
    }

    public void OnBotonMenu() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnBotonSalir() 
    {
        Application.Quit();
    }
}
