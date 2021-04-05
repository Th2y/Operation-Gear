using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;

    private float time;
    public float timer;

    private bool isDead;
    private bool isAttacking;

    public Transform player;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isDead)
        {
            time += Time.deltaTime;

            if (time > timer)
            {
                time = 0;

                float distance = Vector2.Distance(this.transform.position, player.position);

                if (distance <= 1)
                {
                    GetComponent<Agent>().Stop();
                    if (!isAttacking)
                    {
                        animator.SetTrigger("Attack");
                        isAttacking = true;
                    }
                }
                else
                {
                    GetComponent<Agent>().Resume();
                }
            }
        }
    }

    public void OnAttackComplete()
    {
        isAttacking = false;
        Debug.Log("Ataque completo");
    }

    public void TakeDamage(int damage)
    {
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
            Debug.Log("Entrou na área de ataque");
            TakeDamage(20);
        }
    }

}
