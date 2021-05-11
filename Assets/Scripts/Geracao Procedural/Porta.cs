using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public DirecaoMovimento direcao;
    public bool estaConectada;
    [SerializeField]
    private BoxCollider2D colisor;

    [SerializeField]
    private Animator anim;

    public string nomeDaSala;

    public void Conectar(string nome)
    {
        estaConectada = true;
        colisor.isTrigger = true;
        colisor.gameObject.name = nome;
    }

    public virtual void StartAnim()
    {
        if (anim != null)
            StartCoroutine(AnimStart());
        else
            Debug.Log("Coloque uma animação na porta");
    }

    private IEnumerator AnimStart()
    {
        anim.SetBool("Open", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("Open", false);
    }
}
