using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    private List<int> listaSalas;
    public Sala salaInicial;
    public Sala salaFinal;
    public Sala[] salas;

    public int quantidadeSalas;

    void Start()
    {
        listaSalas = new List<int>();

        //Sala sala = Instantiate(salaInicial, Vector3.zero, Quaternion.identity);
        for(int i = 0; i < quantidadeSalas-2; i++)
        {
            Porta porta = salaInicial.escolherPorta();
            salaInicial = EscolherSala();
            salaInicial.Conectar(porta);
            if (i == 0)
                Debug.Log(porta.salaOndeEstou);
        }

        //Sala ultimaSala = Instantiate(salaFinal, Vector3.zero, Quaternion.identity);
        Porta portaFinal = salaInicial.escolherPorta();
        salaFinal.Conectar(portaFinal);
    }

    private Sala EscolherSala()
    {
        Sala sala = null;
        int numSala;
        do
        {
            numSala = Random.Range(0, salas.Length);
            sala = salas[numSala];
        } while (listaSalas.Contains(numSala));

        listaSalas.Add(numSala);
        //sala = Instantiate(salas[numSala], Vector3.zero, Quaternion.identity);
        return sala;
    }
}
