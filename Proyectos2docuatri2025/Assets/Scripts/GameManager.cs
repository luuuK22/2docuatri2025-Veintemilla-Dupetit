using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Tiempo")]
    public float tiempoObjetivo = 60f;
    public Text tiempoTexto;

    [Header("UI")]
    public GameObject menuPausa;
    public Button btnPause; // asignalo desde el Canvas


    private float tiempoActual;
    private bool juegoActivo = true;
    private bool enPausa = false;

    void Start()
    {
        tiempoActual = 0f;
        menuPausa.SetActive(false);

        // Asigno el botón de pausa a la función
        btnPause.onClick.AddListener(Pausar);
    }

    void Update()
    {
        if (!juegoActivo || enPausa) return;

        
        tiempoActual += Time.deltaTime;
        float tiempoRestante = Mathf.Max(tiempoObjetivo - tiempoActual, 0f);
        tiempoTexto.text = "Tiempo: " + tiempoRestante.ToString("F1");

        if (tiempoActual >= tiempoObjetivo)
        {
            Ganar();
        }
    }

    void Ganar()
    {
        juegoActivo = false;
        tiempoTexto.text = "¡Victoria!";
    }

    public void Pausar()
    {
        enPausa = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        enPausa = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    
    public void Menu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }


    public void Salir()
    {
        Application.Quit();
    }

}




