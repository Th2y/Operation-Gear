using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public float startTime = 1f;
    public float dramaTime = 1f;
    public string SceneName;
    public bool isMainMenu = false;

    public AudioSource audio;
    public GameObject startButton;
    public GameObject settingsButton;
    public GameObject exitButton;
    public GameObject title;
    public GameObject settingsUI;
    public GameObject dramaSprite;
    private void Start()
    {
        // Dá lock do mouse na tela e começa a Coroutine da sprite de "drama"
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
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
    }
    public void mediumQuality()
    {
        // Ativa as configurações de média qualidade
        QualitySettings.SetQualityLevel(3, true);
    }
    public void lowQuality()
    {
        // Ativa as configurações de baixa qualidade
        QualitySettings.SetQualityLevel(0, true);
    }
    IEnumerator dramaBegin()
    {
        // Desativa a sprite de "drama" após o tempo determinado
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