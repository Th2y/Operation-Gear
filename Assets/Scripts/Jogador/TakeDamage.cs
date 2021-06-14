using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public GameObject D_I; // Imagem de dano(tela vermelha)


    private StatsController stats;
    private AnimController anim;

    [Header("Sounds")]
    public AudioSource SFX_takedamage;

    private void Start()
    {
        stats = GetComponent<StatsController>();

        anim = GetComponent<AnimController>();    
    }


    // metodo para o jogador sofrer dano
    public void DamageInPlayer(float dmg)
    {
        SFX_takedamage.Play();

        stats.RemoveLife(dmg);

        anim.TakeDamageAnim(true);
        
        DamageImageTrue();

        Invoke("DamageImageFalse", 1f);

    }
    public void DamageImageTrue()
    {
        D_I.SetActive(true);
    }
    public void DamageImageFalse()
    {
        D_I.SetActive(false);
        anim.TakeDamageAnim(false);
    }



}
