using UnityEngine;

public class EscolherBotao : MonoBehaviour
{
    [SerializeField]
    private MovimentacaoJogador jogador;

    public void BotaoMoverBaixo()
    {
        this.jogador.Mover(DirecaoMovimento.Baixo);
    }

    public void BotaoMoverCima()
    {
        this.jogador.Mover(DirecaoMovimento.Cima);
    }

    public void BotaoMoverDireita()
    {
        this.jogador.Mover(DirecaoMovimento.Direita);
    }

    public void BotaoMoverEsquerda()
    {
        this.jogador.Mover(DirecaoMovimento.Esquerda);
    }
}
