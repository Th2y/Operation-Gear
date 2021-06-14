using System.Collections;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public DirecaoMovimento direcao;
    public bool estaConectada;
    [SerializeField]
    private BoxCollider2D colisor;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private SpriteRenderer portaImg;
    [SerializeField]
    private Sprite portaBloqueada;

    public string nomeDaSala;

    public Sala salaOndeEstou;
    public Porta portaConectada;

    public void Conectar(string nome, Porta porta)
    {
        estaConectada = true;
        colisor.isTrigger = true;
        colisor.gameObject.name = nome;
        portaImg.sprite = portaBloqueada;
        portaConectada = porta;
    }

    public void StartAnim()
    {
        if (anim != null)
            StartCoroutine(AnimStart());
        else
            Debug.Log("Coloque uma animação na porta");
    }

    private IEnumerator AnimStart()
    {
        anim.SetInteger("OpenS", 0);
        Debug.Log(anim.GetInteger("OpenS"));
        yield return new WaitForSeconds(200);
        anim.SetInteger("OpenS", 1);
    }
}
