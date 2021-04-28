using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public DirecaoMovimento direcao;
    public bool estaConectada;
    [SerializeField]
    private BoxCollider2D colisor;

    public string nomeDaSala;

    public void Conectar(string nome)
    {
        estaConectada = true;
        colisor.isTrigger = true;
        colisor.gameObject.name = nome;
    }
}
