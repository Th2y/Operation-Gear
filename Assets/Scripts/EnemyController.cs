using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IAgentObserver
{
    public Animator animator;
    private Rigidbody2D rb;

    private float attackTime;
    public float attackTimer;
    private float pushTime;
    public float pushCooldown;
    public float pushForce;
    [Range(0,100)]
    public float pushRate;

    [SerializeField]
    private bool isDead;
    [SerializeField]
    private bool isAttacking;
    [SerializeField]
    private bool isFollowing;
    [SerializeField]
    private bool hasPushed;
    [SerializeField]
    private bool isTackingDamage;

    public GameObject player;
    public GameObject agent;

    public int damage = 10;
    private int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
        rb = GetComponent<Rigidbody2D>();
        isFollowing = false;
        hasPushed = false;
        isTackingDamage = false;
        GetComponent<Agent>().Observer = this;
        CheckPushDistance();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);

        if (!isDead)
        {
            if (isFollowing)
            {
                animator.SetBool("isWalking", true);
                if (hasPushed)
                {
                    pushTime += Time.deltaTime;
                    if (pushTime >= pushCooldown)
                    {
                        pushTime = 0;
                        hasPushed = false;
                        isFollowing = false;
                    }
                }
                else
                {
                    agent.GetComponent<Agent>().movementDelay = (distance - 1) * pushForce;
                    if (distance <= 1)
                    {
                        Vector2 pushDirection = (player.transform.position - this.transform.position).normalized;
                        player.GetComponent<MovimentacaoJogador>().Knockback(pushDirection);
                        hasPushed = true;
                        GetComponent<Agent>().Stop();
                    }
                }
            }
            else
            {
                animator.SetBool("isWalking", false);
                if (distance <= 1)
                {
                    if (!isAttacking && !isTackingDamage)
                    {
                        attackTime += Time.deltaTime;

                        if (attackTime > attackTimer)
                        {
                            attackTime = 0;

                            GetComponent<Agent>().Stop();
                            NormalAttack();

                        }
                    }                   
                }
                else
                {
                    GetComponent<Agent>().Resume();
                }

                agent.GetComponent<Agent>().movementDelay = 1f;
          
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
        GetComponent<Agent>().Stop();
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
        float distance = Vector2.Distance(this.transform.position, player.transform.position);
        distance = Mathf.FloorToInt(distance);

        if (distance == 4)
        {
            float randomChance = Random.Range(0f, 100f);
            if (randomChance <= pushRate)
            {
                isFollowing = true;
            }
            else
            {
                isFollowing = false;
            }
        }
    }

    public void OnMoveComplete()
    {
        CheckPushDistance();
    }
}
