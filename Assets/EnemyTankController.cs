using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;

    public GameObject Player;

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
        if (rb.velocity.x > 0.01 || rb.velocity.x < -0.01)
        {
            animator.SetBool("isWalking", true);
        }
        else if (rb.velocity.x == 0f && rb.velocity.y == 0f)
        {
            animator.SetBool("isWalking", false);

        }
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
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
            Player.GetComponent<PlayerController>().speed -= 0.05f;

        }

        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            TakeDamage(20);
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
            Player.GetComponent<PlayerController>().speed = 0.25f;

        }
    }
}
