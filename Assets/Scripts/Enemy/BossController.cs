using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, IAgentObserver
{
    public Animator animator;
    private Rigidbody2D rb;

    private float dashTime;
    public float dashTimer;
    private float attackTime;
    public float attackTimer;
    private float pushTime;
    public float pushCooldown;
    public float pushForce;
    [Range(0, 100)]
    public float pushRate;

    [SerializeField]
    private bool isDead;
    [SerializeField]
    private bool isAttacking;
    [SerializeField]
    private bool isDashing;
    [SerializeField]
    private bool hasPushed;
    [SerializeField]
    private bool isTackingDamage;
    [SerializeField]
    private bool dashActivated;

    public GameObject player;

    [SerializeField]
    private AttackIndicator attackIndicatorPrefab;

    private AttackIndicator attackIndicator;

    public int damage = 10;
    private int maxHealth = 100;
    private int currentHealth;

    private Agent agent;
    private EnemyTarget enemyTarget;

    void Awake()
    {
        this.agent = GetComponent<Agent>();
        GameObject enemyTargetGameObject = new GameObject();
        enemyTarget = enemyTargetGameObject.AddComponent<EnemyTarget>();
        this.agent.Target = enemyTargetGameObject.transform;
        enemyTarget.agent = agent;
        enemyTarget.Follow();
    }


    // Start is called before the first frame update
    void Start()
    {
        dashTime = 0;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        isDashing = false;
        dashActivated = false;
        hasPushed = false;
        isTackingDamage = false;
        GetComponent<Agent>().Observer = this;
        CheckPushDistance();
    }

    // Update is called once per frame
    void Update()
    {

        float distanceX = Mathf.Abs(this.transform.position.x - enemyTarget.transform.position.x);
        float distanceY = Mathf.Abs(this.transform.position.y - enemyTarget.transform.position.y);
        float distance = distanceX + distanceY;

        if (!isDead)
        {
            if (isDashing)
            {
                //Debug.Log("Estou seguindo");
                animator.SetBool("isWalking", true);
                if (hasPushed)
                {

                    pushTime += Time.deltaTime;
                    if (pushTime >= pushCooldown)
                    {
                        pushTime = 0;
                        hasPushed = false;
                        isDashing = false;
                    }
                }
                else
                {
                    agent.MovementDelay = (distance - 1) * pushForce;
                    if (distance <= 1)
                    {
                        float playerDistance = Vector2.Distance(player.transform.position, enemyTarget.transform.position);
                        if (playerDistance <= Mathf.Epsilon)
                        {
                            Vector2 pushDirection = (player.transform.position - this.transform.position).normalized;
                            player.GetComponent<MovimentacaoJogador>().Knockback(pushDirection);
                        }
                        hasPushed = true;
                        agent.Stop();
                        attackIndicator.Hide();
                        enemyTarget.Follow();
                    }
                }
            }
            else
            {
                if (dashActivated)
                {
                    this.dashTime += Time.deltaTime;
                    if (this.dashTime >= dashTimer)
                    {
                        this.dashTime = 0;
                        isDashing = true;
                        dashActivated = false;
                        agent.Resume();
                    }
                }

                if (distance <= 1)
                {
                    if (!isAttacking && !isTackingDamage)
                    {
                        attackTime += Time.deltaTime;

                        if (attackTime > attackTimer)
                        {
                            attackTime = 0;

                            agent.Stop();
                            NormalAttack();

                        }
                    }
                }
                else
                {
                    if (!dashActivated)
                    {
                        agent.Resume();
                    }

                }

                agent.MovementDelay = 1f;

            }
        }

    }

    private void NormalAttack()
    {
        if (!isAttacking)
        {
            animator.SetTrigger("Attack");
            isAttacking = true;
        }
    }

    public void OnAttackComplete()
    {
        isAttacking = false;

        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        _player.GetComponent<TakeDamage>().DamageInPlayer(damage);
    }

    public void OnAttackCancel()
    {
        isAttacking = false;
    }

    public void OnTackingDamageComplete()
    {
        isTackingDamage = false;
    }

    public void TakeDamage(int damage)
    {
        isTackingDamage = true;
        OnAttackCancel();
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        agent.Stop();
        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            TakeDamage(20);
        }
    }

    private void CheckPushDistance()
    {
        float distanceX = Mathf.Abs(this.transform.position.x - enemyTarget.transform.position.x);
        float distanceY = Mathf.Abs(this.transform.position.y - enemyTarget.transform.position.y);
        float distance = distanceX + distanceY;
        distance = Mathf.FloorToInt(distance);

        if (distance == 4)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance <= pushRate)
            {
                dashActivated = true;
                if (attackIndicator == null)
                {
                    attackIndicator = Instantiate(attackIndicatorPrefab);
                }
                attackIndicator.Show(this.transform.position, agent.GetNodesPositions());
                agent.Stop();
                enemyTarget.StopFollow();

            }
            else
            {
                dashActivated = false;
            }
        }
    }

    public void OnMoveComplete()
    {
        if (!dashActivated)
        {
            CheckPushDistance();
        }

    }
}
