using UnityEngine;

public class JogadorNaHUB : MonoBehaviour
{
    [SerializeField]
    private float distance = 1f;
    [SerializeField]
    private GameObject upDown;
    [SerializeField]
    private GameObject leftRight;
    [SerializeField]
    private LayerMask cameraLimites;

    private Vector2 direcaoV;
    [SerializeField]
    private AnimController animController;

    public void Move(string direcao)
    {
        DirecaoMovimento mover = (DirecaoMovimento)DirecaoMovimento.Parse(typeof(DirecaoMovimento), direcao);
        animController.MoveToDirection(direcao);
        Mover(mover);
    }

    public void Mover(DirecaoMovimento direcao)
    {
        switch (direcao)
        {
            case DirecaoMovimento.Down:
                direcaoV = Vector2.down;
                Movimento();
                break;
            case DirecaoMovimento.Up:
                direcaoV = Vector2.up;
                Movimento();
                break;
            case DirecaoMovimento.Right:
                direcaoV = Vector2.right;
                Movimento();
                break;
            case DirecaoMovimento.Left:
                direcaoV = Vector2.left;
                Movimento();
                break;
        }
    }

    void Movimento()
    {
        RaycastHit2D ray;
        if (direcaoV == Vector2.down || direcaoV == Vector2.up)
            ray = Physics2D.Raycast(upDown.transform.position, upDown.transform.TransformDirection(direcaoV), distance, cameraLimites);
        else
            ray = Physics2D.Raycast(leftRight.transform.position, leftRight.transform.TransformDirection(direcaoV), distance, cameraLimites);

        if (ray.collider == null || ray.collider.isTrigger)
        {
            if (direcaoV == Vector2.down)
                this.transform.position += Vector3.down;
            else if (direcaoV == Vector2.up)
                this.transform.position += Vector3.up;
            else if (direcaoV == Vector2.left)
                this.transform.position += Vector3.left;
            else if (direcaoV == Vector2.right)
                this.transform.position += Vector3.right;
        }
        else
            Debug.Log(ray.collider.gameObject.name);
    }
}
