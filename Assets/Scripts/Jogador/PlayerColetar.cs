using UnityEngine;
using TMPro;

public class PlayerColetar : MonoBehaviour
{
    public TextMeshProUGUI TextColetaveis;
    public static int contarColetaveis = 0;
    private int contadorColetaveis = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coletavel")
        {
            other.gameObject.SetActive(false);
            contadorColetaveis++;
            TextColetaveis.text = contadorColetaveis.ToString();
            contarColetaveis = contadorColetaveis;
        }
    }
}
