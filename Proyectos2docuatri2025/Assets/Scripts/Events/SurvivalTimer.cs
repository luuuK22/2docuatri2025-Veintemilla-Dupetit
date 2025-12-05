using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalTimer : MonoBehaviour
{

    [SerializeField] private Text timerText;

    public static float timeSurvived = 0f;
    private bool isRunning = true;

    void Start()
    {
        timeSurvived = 0f;
        isRunning = true;
    }

    void Update()
    {
        if (!isRunning) return;

        timeSurvived += Time.deltaTime;
        UpdateText();
    }

    private void UpdateText()
    {
        int minutes = Mathf.FloorToInt(timeSurvived / 60f);
        int seconds = Mathf.FloorToInt(timeSurvived % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void StopTimer()
    {
        isRunning = false;
    }
}
