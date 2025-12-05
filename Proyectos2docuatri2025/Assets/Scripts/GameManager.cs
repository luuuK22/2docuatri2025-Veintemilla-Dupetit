using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerLife life;

    [Header("UI")]
    [SerializeField] private Text tiempoTexto;
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private Text textoResultado;
    [SerializeField] private Text textoMonedas;

    [Header("Estado del Juego")]
    public bool juegoActivo = false;
    public bool enPausa = false;

    private float tiempoActual = 0f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        juegoActivo = true;
        panelPausa.SetActive(false);
        panelGameOver.SetActive(false);
    }

    private void Update()
    {
        if (!juegoActivo || enPausa) return;

        
        tiempoActual += Time.deltaTime;

       
        tiempoTexto.text = "Tiempo: " + tiempoActual.ToString("F1");

        if (life.currentHealth <= 0) { GameOver();}
    }

   

    public void TogglePause()
    {
        enPausa = !enPausa;

        if (enPausa)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            panelPausa.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    
    public void GameOver()
    {
        juegoActivo = false;
        Time.timeScale = 1f; 

        int reward = CalcularReward();

       
        GameData.Coins += reward;

        
        panelGameOver.SetActive(true);
        textoResultado.text = $"Sobreviviste {tiempoActual:F1} segundos";
        textoMonedas.text = $"+{reward} monedas";

        Time.timeScale = 0f;
    }

    private int CalcularReward()
    {
        
        return Mathf.FloorToInt(tiempoActual / 3f);
    }

    

 

    public void BotonReintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BotonSalirAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Home");
    }

}


