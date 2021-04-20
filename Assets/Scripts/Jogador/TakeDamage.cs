using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private StatsController stats;
    private AnimController anim;
    private void Start()
    {
        stats = GetComponent<StatsController>();
        anim = GetComponent<AnimController>();
    }

    // metodo para o jogador sofrer dano
    public void DamageInPlayer(float dmg)
    {
        anim.TakeDamageAnim();
        stats.life -= dmg;

    }



}
