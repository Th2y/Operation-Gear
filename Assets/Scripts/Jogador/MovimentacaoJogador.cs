using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    [SerializeField]
    private float distance = .4f;
    [SerializeField]
    private GameObject up;
    [SerializeField]
    private GameObject down;
    [SerializeField]
    private GameObject left;
    [SerializeField]
    private GameObject right;
    [SerializeField]
    private LayerMask cameraLimites;

    private Vector2 direcaoV;

    public void Mover(DirecaoMovimento direcao)
    {
        if (StatsController.instance.energy > 0 || Poweraps.instancia.usandoPower)
        {
            switch (direcao)
            {
                case DirecaoMovimento.Baixo:
                    direcaoV = Vector2.down;
                    Movimento();
                    break;
                case DirecaoMovimento.Cima:
                    direcaoV = Vector2.up;
                    Movimento();
                    break;
                case DirecaoMovimento.Direita:
                    direcaoV = Vector2.right;
                    Movimento();
                    break;
                case DirecaoMovimento.Esquerda:
                    direcaoV = Vector2.left;
                    Movimento();
                    break;
            }
        } else Debug.Log("Sem energia");
    }

    void Movimento()
    {
        RaycastHit2D ray = Physics2D.Raycast(up.transform.position, up.transform.TransformDirection(direcaoV), distance, cameraLimites);
        if (ray.collider == null)
        {
            if(direcaoV == Vector2.down)
                this.transform.position += Vector3.down;
            else if (direcaoV == Vector2.up)
                this.transform.position += Vector3.up;
            else if (direcaoV == Vector2.left)
                this.transform.position += Vector3.left;
            else if (direcaoV == Vector2.right)
                this.transform.position += Vector3.right;

            if (!Poweraps.instancia.usandoPower)
                StatsController.instance.RemoveEnergy(1);
        }
    }
}
