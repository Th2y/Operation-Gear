using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    [SerializeField]
    private float distance = 1f;
    [SerializeField]
    private GameObject up;
    [SerializeField]
    private LayerMask cameraLimites;
    [SerializeField]
    private CinemachineChange cinemachineChange;

    private Vector2 direcaoV;

    private bool isPushing = false;
    public float timer;
    private float time;
    public int distanceKnockback;
    public GameObject enemy;
    private Vector2 pushTargetPosition;
    private Vector2 pushDirection;
    public LayerMask collisionLayers;

    private void Update()
    {
        if (isPushing)
        {
            float distance = Vector3.Distance(this.transform.position, pushTargetPosition);
            Debug.Log(distance);
            if (distance < 1)
            {
                isPushing = false;
            }
            else
            {
                time += Time.deltaTime;

                if (time >= timer)
                {
                    time = 0;

                    this.transform.position += (Vector3)pushDirection;
                }
            }
        }
    }

    public void Mover(DirecaoMovimento direcao)
    {
        if ((StatsController.instance.energy > 0 || Poweraps.instancia.usandoPower) && !isPushing)
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
    }

    void Movimento()
    {
        RaycastHit2D ray = Physics2D.Raycast(up.transform.position, up.transform.TransformDirection(direcaoV), distance, cameraLimites);
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

            if (!Poweraps.instancia.usandoPower)
                StatsController.instance.RemoveEnergy(1);
        }
    }

    public void Knockback(Vector2 direction)
    {
        isPushing = true;

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, distanceKnockback, collisionLayers);

        float distance;

        if (hit.transform != null)
        {
            distance = Mathf.FloorToInt(hit.distance);
            distance = Mathf.Max(distance, 0);
        }
        else
        {
            distance = distanceKnockback;
        }

        pushTargetPosition = (Vector2)this.transform.position + (direction * distance);

        this.pushDirection = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portas"))
            cinemachineChange.MudarCam(collision.gameObject.name);
    }
}
