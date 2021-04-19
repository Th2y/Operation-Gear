using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuButtons : MonoBehaviour
{
    public bool debugMode = false;
    public float startTime = 1f;
    public float dramaTime = 1f;
    public float fallSpeed = 1f;
    public float fallAcceleration = 1f;
    public string SceneName;
    public bool isMainMenu = false;

    public Color colorSelected = Color.white;
    public Color colorUnselected = Color.white;

    public AudioSource audio;
    public GameObject startButton;
    public GameObject settingsButton;
    public GameObject exitButton;
    public GameObject title;
    public GameObject settingsUI;
    public GameObject dramaSprite;

    [Header("Fill da barra de Gráficos")]
    public GameObject fillLow;
    public GameObject fillMedium;
    public GameObject fillHigh;
    public Text textLow;
    public Text textMedium;
    public Text textHigh;
    private void Start()
    {
        // Dá lock do mouse na tela e começa a Coroutine da sprite de "drama"
        if (!debugMode)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (isMainMenu)
        {
            StartCoroutine(dramaBegin());
        }
    }
    public void play()
    {
        // Toca um áudio e pula para a Scene especificada no editor ao fim da Coroutine
        audio.Play();
        StartCoroutine(startCoroutine());
    }
    public void settings()
    {
        // Desabilita a UI do menu principal e habilita a UI do menu de configurações
        startButton.SetActive(false);
        settingsButton.SetActive(false);
        exitButton.SetActive(false);
        title.SetActive(false);
        settingsUI.SetActive(true);
    }
    public void settingsExit()
    {
        // Desabilita a UI do menu de configurações e habilita a UI do menu principal
        startButton.SetActive(true);
        settingsButton.SetActive(true);
        exitButton.SetActive(true);
        title.SetActive(true);
        settingsUI.SetActive(false);
    }
    public void exit()
    {
        // Fecha o jogo
        Application.Quit();
    }
    public void highQuality()
    {
        // Ativa as configurações de alta qualidade
        QualitySettings.SetQualityLevel(5, true);
        fillLow.SetActive(true);
        fillMedium.SetActive(true);
        fillHigh.SetActive(true);
        textLow.color = colorSelected;
        textMedium.color = colorSelected;
        textHigh.color = colorSelected;
    }
    public void mediumQuality()
    {
        // Ativa as configurações de média qualidade
        QualitySettings.SetQualityLevel(3, true);
        fillLow.SetActive(true);
        fillMedium.SetActive(true);
        fillHigh.SetActive(false);
        textLow.color = colorSelected;
        textMedium.color = colorSelected;
        textHigh.color = colorUnselected;
    }
    public void lowQuality()
    {
        // Ativa as configurações de baixa qualidade
        QualitySettings.SetQualityLevel(0, true);
        fillLow.SetActive(true);
        fillMedium.SetActive(false);
        fillHigh.SetActive(false);
        textLow.color = colorSelected;
        textMedium.color = colorUnselected;
        textHigh.color = colorUnselected;
    }
    IEnumerator dramaBegin()
    {
        // Desativa a sprite de "drama" após o tempo determinado
        dramaSprite.SetActive(true);
        yield return new WaitForSeconds(dramaTime);
        dramaSprite.SetActive(false);
    }
    IEnumerator startCoroutine()
    {
        // Muda para a Scene determinada após o tempo determinado
        yield return new WaitForSeconds(startTime);
        SceneManager.LoadScene(this.SceneName);
    }
}