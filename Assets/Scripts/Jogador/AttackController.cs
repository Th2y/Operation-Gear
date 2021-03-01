using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("     Attack")]
    public Transform Attackpoint;  // local do dano
    public int damage;             // dano total
    public float radius;           // raio do dano
    public LayerMask layerDamage;  // layers que poderâo sofrer dano

    private ACAttack controls;     // new input


    private void Awake()
    {
        controls = new ACAttack();

        controls.Action.Attack.performed += _ => PlayerAttack();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void PlayerAttack()
    {
        
        //cria um circulo ao redor do attackpoint que detecta a layerdamage
        Collider2D[] hitinfo = Physics2D.OverlapCircleAll(Attackpoint.position,radius,layerDamage);
        
        foreach (Collider2D hit in hitinfo)
        {
            //confere a tag do objeto
            if (hit.gameObject.CompareTag("Object"))
            {
                Debug.Log("atacou");
                hit.GetComponent<ObjectTest>().Takedamage(damage);
            }
        }

    }

    private void OnDrawGizmos()
    {
        //mostra o raio de ataque 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attackpoint.position,radius);
    }
}
