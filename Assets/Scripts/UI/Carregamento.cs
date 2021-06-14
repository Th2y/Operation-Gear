using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Carregamento : MonoBehaviour
{
    public float TempoFixoSeg = 5;
    public Slider barraDeCarregamento;
    public TextMeshProUGUI TextoProgresso;
    private int progresso = 0;
    public static bool novoJogo;

    void Start()
    {
        novoJogo = true;

        StartCoroutine(CenaDeCarregamento("Piso1"));
        /*
        if (barraDeCarregamento != null)
        {
            barraDeCarregamento.type = Image.Type.Filled;
            barraDeCarregamento.fillMethod = Image.FillMethod.Horizontal;
            barraDeCarregamento.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
        */
    }

    IEnumerator CenaDeCarregamento(string cena)
    {
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
        carregamento.allowSceneActivation = false;
        while (progresso < 89)
        {
            progresso = (int) (carregamento.progress * 100.0f);
            yield return null;
        }
        progresso = 100;
        yield return new WaitForSeconds(2);
        carregamento.allowSceneActivation = true;
    }

    void Update()
    {
        if (TextoProgresso != null)
            TextoProgresso.text = "Carregando... " + progresso + "%";

        if (barraDeCarregamento != null)
            barraDeCarregamento.value = progresso;
      //    barraDeCarregamento.fillAmount = (progresso / 100.0f);
    }
}