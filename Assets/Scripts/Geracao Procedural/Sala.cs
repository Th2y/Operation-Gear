using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sala : MonoBehaviour
{
    public Porta[] portas;
    public Transform posInicial;

    [SerializeField]
    private Stage stage;

    public Porta RetornaPortaOposta(DirecaoMovimento direcao)
    {
        DirecaoMovimento direcaoOposta = direcao.Oposta();
        for(int i = 0; i < portas.Length; i++)
        {
            if(portas[i].direcao == direcaoOposta)
            {
                return portas[i];
            }
        }

        return null;
    }

    public void OnEnable()
    {
        if(this.gameObject.name == "Sala 2")
        {
            stage.Iniciar();
        }
    }

    public Porta escolherPorta()
    {
        Porta portaAtual = null;

        do {
            portaAtual = portas[Random.Range(0, portas.Length)];
        }
        while (portaAtual == null || portaAtual.estaConectada);

        return portaAtual;
    }

    public void Conectar(Porta portaConectar)
    {
        this.transform.position = portaConectar.transform.position;
        //Vector3 posInicialGlobal = posInicial.TransformPoint(Vector3.zero);
        //Vector3 distancia = this.transform.position - posInicialGlobal;
        //this.transform.position += distancia;

        Porta portaConectada = RetornaPortaOposta(portaConectar.direcao);
        Vector3 posConectadaGlobal = portaConectada.transform.TransformPoint(Vector3.zero);
        Vector3 distanciaPortas = this.transform.position - posConectadaGlobal;

        this.transform.position += distanciaPortas;

        portaConectar.Conectar(this.gameObject.name, portaConectada);
        portaConectada.Conectar(portaConectar.nomeDaSala, portaConectar);
    }

    public void Ativar()
    {
        Sala[] salas = GameObject.FindObjectsOfType<Sala>();
        for(int i = 0; i < salas.Length; i++)
        {
            salas[i].gameObject.SetActive(false);
        }

        this.gameObject.SetActive(true);

        for(int i=0; i < portas.Length; i++)
        {
            if (portas[i].estaConectada)
            {
                portas[i].portaConectada.salaOndeEstou.gameObject.SetActive(true);
            }
        }
    }
}
