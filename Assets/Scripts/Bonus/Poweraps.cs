using System.Collections;
using UnityEngine;
using TMPro;

public class Poweraps : MonoBehaviour
{
    public bool usandoPower = false;
    public TextMeshProUGUI TextUsandoPower;
    private int mov = 5;
    WaitForSeconds esperar = new WaitForSeconds(.5f);

    [SerializeField]
    private MovimentacaoJogador jogador;

    public static Poweraps instancia;

    void Start()
    {
        instancia = this;
    }

    public void MoveSozinho()
    {
        usandoPower = true;        
    }

    public void MoverSo(DirecaoMovimento direcao)
    {
        StopCoroutine("EscolherDirecao");
        StartCoroutine("EscolherDirecao", direcao);
    }

    IEnumerator EscolherDirecao(DirecaoMovimento direcao)
    {
        usandoPower = true;
        TextUsandoPower.gameObject.SetActive(true);
        while (mov > 0)
        {
            this.jogador.Mover(direcao);
            mov--;

            yield return esperar;
        }

        usandoPower = false;
        if (!usandoPower)
        {
            TextUsandoPower.gameObject.SetActive(false);
            mov = 5;
        }
    }
}
