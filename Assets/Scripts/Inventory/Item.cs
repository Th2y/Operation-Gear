using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";   // Nome do item
    public Sprite icon = null;             // Item icone
    public bool isDefaultItem = false;
    protected StatsController stats;



    public virtual void Use()
    {
        stats = FindObjectOfType<StatsController>();

        Debug.Log("use item");

    }
}
