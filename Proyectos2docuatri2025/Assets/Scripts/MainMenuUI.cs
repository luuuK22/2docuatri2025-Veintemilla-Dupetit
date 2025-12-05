using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{
    [Header("Top Bar")]
    [SerializeField] private Text coinsText;
    [SerializeField] private Text staminaText;

    [Header("Panels")]
    [SerializeField] private GameObject menuPanel;     // MENÚ PRINCIPAL
      
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject levelSelectPanel;

    [Header("Camera Zoom (Nuevo)")]
    public Camera menuCamera;
    public Transform zoomTarget;
    public float zoomDuration = 1.2f;
    public Transform cameraStartPoint;
    private bool isZooming = false;

    private void Start()
    {
        GameData.RegenerateStamina();
        UpdateHeader();
        CloseAllPanels();

       
        menuPanel.SetActive(true);
    }

    private void UpdateHeader()
    {
        coinsText.text = $"Monedas: {GameData.Coins}";
        staminaText.text = $"Energía: {GameData.CurrentStamina}/{GameData.MaxStamina}";
    }

    private void CloseAllPanels()
    {
        shopPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
    }

   
    public void OnPlayPressed()
    {
        if (!isZooming)
            StartCoroutine(ZoomToLoop());
    }

    private IEnumerator ZoomToLoop()
    {
        isZooming = true;

        Vector3 startPos = menuCamera.transform.position;
        Quaternion startRot = menuCamera.transform.rotation;

        Vector3 endPos = zoomTarget.position;
        Quaternion endRot = zoomTarget.rotation;

        float t = 0f;

        while (t < zoomDuration)
        {
            t += Time.deltaTime;
            float normalized = t / zoomDuration;

            menuCamera.transform.position = Vector3.Lerp(startPos, endPos, normalized);
            menuCamera.transform.rotation = Quaternion.Lerp(startRot, endRot, normalized);

            yield return null;
        }

      
        isZooming = false;
        menuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }

    public void Exit()
    { 
        
        Application.Quit();

    }
    public void OpenShop()
    {
        levelSelectPanel.SetActive(false);
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void GoToscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }   

    public void BackToMainMenu()
    {
      
        menuPanel.SetActive(true);

       
        shopPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        
        StartCoroutine(ZoomBack());
    }

  
    private IEnumerator ZoomBack()
    {
        Vector3 startPos = menuCamera.transform.position;
        Quaternion startRot = menuCamera.transform.rotation;

        Vector3 endPos = cameraStartPoint.position;
        Quaternion endRot = cameraStartPoint.rotation;

        float t = 0f;

        while (t < zoomDuration)
        {
            t += Time.deltaTime;
            float normalized = t / zoomDuration;

            menuCamera.transform.position = Vector3.Lerp(startPos, endPos, normalized);
            menuCamera.transform.rotation = Quaternion.Lerp(startRot, endRot, normalized);

            yield return null;
        }

        isZooming = false;
    }
}
