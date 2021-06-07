using UnityEngine;

public class EscolherBotao : MonoBehaviour
{
    [SerializeField]
    private MovimentacaoJogador jogador;
    [SerializeField]
    private AnimController animController;

    public void Move(string direcao)
    {
        DirecaoMovimento mover = (DirecaoMovimento)DirecaoMovimento.Parse(typeof(DirecaoMovimento), direcao);
        animController.MoveToDirection(direcao);
        BotaoMover(mover);
    }

    private void BotaoMover(DirecaoMovimento direcao)
    {
        if (!Poweraps.instancia.usandoPower)
            this.jogador.Mover(direcao);
        else
            Poweraps.instancia.MoverSo(direcao);
    }
}
