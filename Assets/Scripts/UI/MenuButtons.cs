using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    private bool debugMode = false;
    private float startTime = 1f;
    private float dramaTime = 1f;
    private float fallSpeed = 1f;
    private float fallAcceleration = 1f;
    public string SceneName;
    public bool isMainMenu = false;
    public bool isPaused = false;

    [SerializeField]
    private Color colorSelected = Color.white;
    [SerializeField]
    private Color colorUnselected = Color.white;
    [SerializeField]
    private Color colorCurrent = Color.white;

    [SerializeField]
    private AudioSource audios;
    [SerializeField]
    private GameObject dramaSprite;

    [Header("Fill da barra de Gráficos")]
    [SerializeField]
    private GameObject fillLow;
    [SerializeField]
    private GameObject fillMedium;
    [SerializeField]
    private GameObject fillHigh;
    [SerializeField]
    private Text textLow;
    [SerializeField]
    private Text textMedium;
    [SerializeField]
    private Text textHigh;

    private void Start()
    {
        // Dá lock do mouse na tela e começa a Coroutine da sprite de "drama"
        // Reativar caso fizermos para pc também
        /*if (!debugMode)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }*/
        if (isMainMenu)
        {
            StartCoroutine(DramaBegin());
        }
    }
    public void Play()
    {
        // Toca um áudio e pula para a Scene especificada no editor ao fim da Coroutine
        audios.Play();
        StartCoroutine(CarregarFases());
    }
    public void Exit()
    {
        // Fecha o jogo
        Application.Quit();
    }
    public void timeStop()
    {
        if (isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }
    public void HighQuality()
    {
        // Ativa as configurações de alta qualidade
        QualitySettings.SetQualityLevel(5, true);
        fillLow.SetActive(true);
        fillMedium.SetActive(true);
        fillHigh.SetActive(true);
        textLow.color = colorSelected;
        textMedium.color = colorSelected;
        textHigh.color = colorCurrent;
    }
    public void MediumQuality()
    {
        // Ativa as configurações de média qualidade
        QualitySettings.SetQualityLevel(3, true);
        fillLow.SetActive(true);
        fillMedium.SetActive(true);
        fillHigh.SetActive(false);
        textLow.color = colorSelected;
        textMedium.color = colorCurrent;
        textHigh.color = colorUnselected;
    }
    public void LowQuality()
    {
        // Ativa as configurações de baixa qualidade
        QualitySettings.SetQualityLevel(0, true);
        fillLow.SetActive(true);
        fillMedium.SetActive(false);
        fillHigh.SetActive(false);
        textLow.color = colorCurrent;
        textMedium.color = colorUnselected;
        textHigh.color = colorUnselected;
    }
    IEnumerator DramaBegin()
    {
        // Desativa a sprite de "drama" após o tempo determinado
        dramaSprite.SetActive(true);
        yield return new WaitForSeconds(dramaTime);
        dramaSprite.SetActive(false);
    }
    IEnumerator CarregarFases()
    {
        // Muda para a Scene determinada após o tempo determinado
        yield return new WaitForSeconds(startTime);
        SceneManager.LoadScene(SceneName);
    }
}