using UnityEngine;

public class ColetarChaves : ObjectController
{
    private int numChavesColetadas = 0;
    private int numChavesNaSala = 2;
    [SerializeField]
    private string nomeDaCena = "Piso1";

    public override void Takedamage(int dmg)
    {
        life = 0;
        numChavesColetadas++;
        if (numChavesColetadas == numChavesNaSala)
            Debug.Log("Todas as chaves foram encontradas");

        Destroy(gameObject, 1.5f);
    }
}
