using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool wasPickedUp = Inventory.instance.AddItem(item);
            if (wasPickedUp)
                Destroy(gameObject);
        }
    }

}
