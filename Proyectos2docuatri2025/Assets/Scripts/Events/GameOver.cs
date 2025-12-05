using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    [SerializeField] private Text finalTimeText;

    void Start()
    {
        float time = SurvivalTimer.timeSurvived;

        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);

        finalTimeText.text = $"Tiempo sobrevivido: {minutes:00}:{seconds:00}";
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene"); // Cambia al nombre real de tu escena de juego
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
