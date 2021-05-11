using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";   // Nome do item
    public Sprite icon = null;             // Item icone
    public bool isDefaultItem = false;




    public virtual void Use()
    {

        Debug.Log("use item");

    }
}
