using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public AudioSource SFX_Pickup;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool wasPickedUp = Inventory.instance.AddItem(item);
            if (wasPickedUp)
                SFX_Pickup.Play();
                Destroy(gameObject);
        }
    }

}
