using UnityEngine;

public class EscolherBotao : MonoBehaviour
{
    [SerializeField]
    private MovimentacaoJogador jogador;

    public void Move(string direcao)
    {
        DirecaoMovimento mover = (DirecaoMovimento)DirecaoMovimento.Parse(typeof(DirecaoMovimento), direcao);  // Animal.Dog
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
