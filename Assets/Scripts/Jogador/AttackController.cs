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
    public static bool IsAttaking; // (verifica)player atacando

    [Header("      Time Attack")]
    public float TimeAttack;       // tempo total pro player atacar
    public float T_A;              // tempo pro player atacar

    private ACAttack controls;     // new input


    private void Awake()
    {
        controls = new ACAttack();

        controls.Action.Attack.performed += x => IsAttaking = x.ReadValueAsButton();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        // confere se o player está atacando e se o tempo de atacar chegou
        if (T_A <= 0 && IsAttaking)
        {
            PlayerAttack();
            T_A = TimeAttack;
        }
        else 
        {
            T_A -= Time.deltaTime;
        }
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

        //remove energia 
        StatsController.instance.RemoveEnergy(2);
    }

    private void OnDrawGizmos()
    {
        //mostra o raio de ataque 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Attackpoint.position,radius);
    }
}
