using UnityEngine;
using TMPro;

public class Poweraps : MonoBehaviour
{
    public static Poweraps instancia;
    public bool usandoPower = false;
    public float tempoPower = 2f;

    public TextMeshProUGUI TextColetaveis;
    public static int contarColetaveis = 0;
    public int contadorColetaveis = 0;

    void Start()
    {
        instancia = this;
    }

    private void Update()
    {
        if (usandoPower)
        {
            tempoPower -= Time.deltaTime;
            if(tempoPower <= 0)
            {
                tempoPower = 2f;
                usandoPower = false;
            }

            Debug.Log("Usando power");
        }
    }

    //No momento, apenas impede que o jogador gaste estamina ao se mover, porém deve fazer com que ele se mova sozinho na direção escolhida
    public void MoveSozinho()
    {
        contadorColetaveis++;
        TextColetaveis.text = contadorColetaveis.ToString();
        contarColetaveis = contadorColetaveis;
        StatsController.instance.energy = StatsController.instance.maxenergy;
        usandoPower = true;
    }
}
