using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public AudioSource audio;
    public string SceneName;
    public GameObject startButton;
    public GameObject settingsButton;
    public GameObject exitButton;
    public GameObject title;
    public GameObject settingsUI;
    public GameObject dramaSprite;
    public bool isMainMenu = false;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        if (isMainMenu)
        {
            StartCoroutine(dramaBegin());
        }
    }
    public void play()
    {
        audio.Play();
        StartCoroutine(startCoroutine());
    }
    public void settings()
    {
        startButton.SetActive(false);
        settingsButton.SetActive(false);
        exitButton.SetActive(false);
        title.SetActive(false);
        settingsUI.SetActive(true);
    }
    public void settingsExit()
    {
        startButton.SetActive(true);
        settingsButton.SetActive(true);
        exitButton.SetActive(true);
        title.SetActive(true);
        settingsUI.SetActive(false);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void highQuality()
    {
        QualitySettings.SetQualityLevel(5, true);
    }
    public void mediumQuality()
    {
        QualitySettings.SetQualityLevel(3, true);
    }
    public void lowQuality()
    {
        QualitySettings.SetQualityLevel(0, true);
    }
    IEnumerator dramaBegin()
    {
        yield return new WaitForSeconds(1f);
        dramaSprite.SetActive(false);
    }
    IEnumerator startCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(this.SceneName);
    }
}