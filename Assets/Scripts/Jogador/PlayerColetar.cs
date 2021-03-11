using UnityEngine;

public class PlayerColetar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coletavel")
        {
            other.gameObject.SetActive(false);
            Poweraps.instancia.MoveSozinho();
        }
    }
}
