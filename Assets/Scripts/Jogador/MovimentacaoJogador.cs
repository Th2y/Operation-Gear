using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    public void Mover(DirecaoMovimento direcao)
    {
        if (StatsController.instance.energy > 0 || Poweraps.instancia.usandoPower)
        {
            switch (direcao)
            {
                case DirecaoMovimento.Baixo:
                    this.transform.position += (Vector3.down/2);
                    break;
                case DirecaoMovimento.Cima:
                    this.transform.position += (Vector3.up/2);
                    break;
                case DirecaoMovimento.Direita:
                    this.transform.position += (Vector3.right/2);
                    break;
                case DirecaoMovimento.Esquerda:
                    this.transform.position += (Vector3.left/2);
                    break;
            }

            if(!Poweraps.instancia.usandoPower)
                StatsController.instance.RemoveEnergy(1);
        } else Debug.Log("Sem energia");
    }
}
