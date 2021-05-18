using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHUB : MonoBehaviour
{
    [SerializeField]
    private AudioSource audios;

    public void Play()
    {
        // Toca um áudio e pula para a Scene especificada no editor ao fim da Coroutine
        //audios.Play();
        StartCoroutine(CarregarFases());
    }

    IEnumerator CarregarFases()
    {
        // Muda para a Scene determinada após o tempo determinado
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Carregamento");
    }
}
