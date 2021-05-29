using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : ObjectController
{
    [SerializeField]
    private Sprite[] imagebox;
    [SerializeField]
    private ParticleSystem explosao;

    private int maquinasDestruidas = 0;
    private string nomeDaFase = "Piso1";
    private string maquinasSave;

    private void Start()
    {
        // a vida da caixa torna-se o numero de sprites
        life = imagebox.Length - 1;
        maquinasSave = "MaquinasDestruidas" + nomeDaFase;
        if (PlayerPrefs.HasKey(maquinasSave))
            PlayerPrefs.SetInt(maquinasSave, maquinasDestruidas);
    }

    public override void Takedamage(int dmg)
    {
        life -= dmg;

        anim.SetInteger("Vidas", life);
        if (life <= 3)
        {
            var main = explosao.main;
            main.maxParticles++;
            explosao.Play();
        }

        if (life <= 0)
        {
            maquinasDestruidas = PlayerPrefs.GetInt(maquinasSave) + 1;
            PlayerPrefs.SetInt(maquinasSave, maquinasDestruidas);
            Destroy(gameObject, 1f);
        }
    }
}
