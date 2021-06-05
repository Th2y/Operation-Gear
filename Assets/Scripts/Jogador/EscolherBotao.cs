using UnityEngine;
using UnityEngine.SceneManagement;

public class EscolherBotao : MonoBehaviour
{
    [SerializeField]
    private MovimentacaoJogador jogador;
    [SerializeField]
    private AnimController animController;
    [SerializeField]
    private ReloadScene reloadScene;

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

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        reloadScene.Reloadscene();
    }

    public void IrParaOMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HUB");
    }
}
