using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioSource SFX_Pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SFX_Pickup.Play();
            CoinsSystem.instance.UpdateCoins();
        }
    }
}
