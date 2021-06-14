using UnityEngine;

public class MovimentacaoJogador : MonoBehaviour
{
    [SerializeField]
    private float distance = 1f;
    [SerializeField]
    private GameObject upDown;
    [SerializeField]
    private GameObject leftRight;
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
            Debug.Log("Distância: " + distance);
            Debug.Log("PushDirection: " + pushDirection);
            if (distance <= Mathf.Epsilon)
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
        RaycastHit2D ray;
        if(direcaoV == Vector2.down || direcaoV == Vector2.up)
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

            if (!Poweraps.instancia.usandoPower)
                StatsController.instance.RemoveEnergy(1);
        }
        //else
            //Debug.Log(ray.collider.gameObject.name);
    }

    public void Knockback(Vector2 direction)
    {
        isPushing = true;

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, distanceKnockback, collisionLayers);

        float distance;

        if (hit.transform != null)
        {
            Debug.Log(hit.transform.name);
            distance = Mathf.FloorToInt(hit.distance);
            distance = Mathf.Max(distance, 0);
        }
        else
        {
            distance = distanceKnockback;
        }
        Debug.Log("Distancia knockback: " + distance);
        pushTargetPosition = (Vector2)this.transform.position + (direction * distance);

        this.pushDirection = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portas"))
        {
            Porta porta = collision.GetComponent<Porta>();
            cinemachineChange.MudarCam(collision.gameObject.name);
            porta.StartAnim();
            porta.portaConectada.StartAnim();
            porta.portaConectada.salaOndeEstou.SetAtivo(true);
        }
        else if (collision.gameObject.CompareTag("Chaves"))
        {
            Debug.Log("Encontrei uma chave");
            collision.GetComponent<ColetarChaves>().Takedamage(1);
        }
    }
}
