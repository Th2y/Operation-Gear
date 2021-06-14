using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public int iDImage;
    Item item;
    public Image icon;

    [Header("Sounds")]
    public AudioSource SFX_Use;




    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = newItem.icon;
        icon.enabled = true;
    }


    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;


    }
    public void OnRemoveButton()
    {
        
        ClearSlot();
    }



    public void useItem()
    {
        if (item != null)
        {
            item.Use();

            SFX_Use.Play();

            Inventory.instance.RemoveItem(item);

            ClearSlot();


            

        }

    }

}
