using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHUB : MonoBehaviour
{
    [SerializeField]
    private AudioSource audios;
    [SerializeField]
    private JogadorNaHUB jogadorNaHUB;
    [SerializeField]
    private GameObject[] painelLoja;
    private string oQueCarregar;

    public void MoveNaHUB(string direcao)
    {
        DirecaoMovimento mover = (DirecaoMovimento)DirecaoMovimento.Parse(typeof(DirecaoMovimento), direcao);
        this.jogadorNaHUB.Mover(mover);
    }

    public void MudarOQueCarregar(string name)
    {
        oQueCarregar = name;
    }

    public void ConfirmarNaHUb()
    {
        if (oQueCarregar == "Jogar")
        {
            //Lógica para escolher qual cena carregar
            // Toca um áudio e pula para a Scene especificada no editor ao fim da Coroutine
            audios.Play();
            SceneManager.LoadScene("Carregamento");
        }
        else if (oQueCarregar == "Loja1")
            painelLoja[0].SetActive(true);
        else if (oQueCarregar == "Loja2")
            painelLoja[1].SetActive(true);
        else if (oQueCarregar == "Loja3")
            painelLoja[2].SetActive(true);
        else if (oQueCarregar == "Loja4")
            painelLoja[3].SetActive(true);
        else if (oQueCarregar == "Loja5")
            painelLoja[4].SetActive(true);
    }
}
