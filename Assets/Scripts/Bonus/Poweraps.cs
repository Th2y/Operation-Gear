using System.Collections;
using UnityEngine;
using TMPro;

public class Poweraps : MonoBehaviour
{
    public static Poweraps instancia;
    public bool usandoPower = false;

    public TextMeshProUGUI TextColetaveis;
    public static int contarColetaveis = 0;
    public int contadorColetaveis = 0;

    WaitForSeconds delay = new WaitForSeconds(1);

    [SerializeField]
    private MovimentacaoJogador jogador;

    void Start()
    {
        instancia = this;
    }

    //No momento, apenas impede que o jogador gaste estamina ao se mover, porém deve fazer com que ele se mova sozinho na direção escolhida
    public void MoveSozinho()
    {
        contadorColetaveis++;
        TextColetaveis.text = contadorColetaveis.ToString();
        contarColetaveis = contadorColetaveis;
        StatsController.instance.energy = StatsController.instance.maxenergy;
        usandoPower = true;        
    }

    public void MoverSo(DirecaoMovimento direcao)
    {
        StartCoroutine("EscolherDirecao", direcao);
    }

    IEnumerator EscolherDirecao(DirecaoMovimento direcao)
    {
        int i = 5;

        while (i > 0)
        {
            this.jogador.Mover(direcao);
            i--;

            yield return delay;
        }
        Poweraps.instancia.usandoPower = false;
    }
}
