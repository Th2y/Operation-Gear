using UnityEngine;

public class EscolherBotao : MonoBehaviour
{
    [SerializeField]
    private MovimentacaoJogador jogador;
    [SerializeField]
    private AnimController animController;
    private float tempoClique = .4f;
    private bool clicou = false;

    private void Update()
    {
        if (clicou)
        {
            tempoClique -= Time.deltaTime;
            if (tempoClique <= 0)
            {
                tempoClique = .4f;
                clicou = false;
            }
        }
    }

    public void Move(string direcao)
    {
        if(!clicou)
        {
            DirecaoMovimento mover = (DirecaoMovimento)DirecaoMovimento.Parse(typeof(DirecaoMovimento), direcao);
            animController.MoveToDirection(direcao);
            BotaoMover(mover);
            clicou = true;
        }
    }

    private void BotaoMover(DirecaoMovimento direcao)
    {
        if (!Poweraps.instancia.usandoPower)
            this.jogador.Mover(direcao);
        else
            Poweraps.instancia.MoverSo(direcao);
    }
}
