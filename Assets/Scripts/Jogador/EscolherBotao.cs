using UnityEngine;

public class EscolherBotao : MonoBehaviour
{
    [SerializeField]
    private MovimentacaoJogador jogador;

    public void BotaoMoverBaixo()
    {
        if (Poweraps.instancia.usandoPower)
        {           
            for (int i = 0; i < 10; i++)
            {
                this.jogador.Mover(DirecaoMovimento.Baixo);
            }
        }
        else
            this.jogador.Mover(DirecaoMovimento.Baixo);
    }

    public void BotaoMoverCima()
    {
        if (Poweraps.instancia.usandoPower)
        {
            for (int i = 0; i < 10; i++)
            {
                this.jogador.Mover(DirecaoMovimento.Cima);
            }
        }
        else
            this.jogador.Mover(DirecaoMovimento.Cima);
    }

    public void BotaoMoverDireita()
    {
        if (Poweraps.instancia.usandoPower)
        {
            for (int i = 0; i < 10; i++)
            {
                this.jogador.Mover(DirecaoMovimento.Direita);
            }
        }
        else
            this.jogador.Mover(DirecaoMovimento.Direita);
    }

    public void BotaoMoverEsquerda()
    {
        if (Poweraps.instancia.usandoPower)
        {
            for (int i = 0; i < 10; i++)
            {
                this.jogador.Mover(DirecaoMovimento.Esquerda);
            }
        }
        else
            this.jogador.Mover(DirecaoMovimento.Esquerda);
    }
}
