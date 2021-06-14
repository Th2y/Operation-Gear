using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypePotion
{
    Life,
    Energy
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Potions")]
public class Potions : Item
{
    public TypePotion potion;         //tipo de poção
    [Range(0,100)]public int Value;   //quantidade que vai ganhar
    public override void Use()
    {
        base.Use();

        if (potion == TypePotion.Life) 
        {
            stats.life += Value;
        }
        else if (potion == TypePotion.Energy)
        {
            stats.energy += Value;
        }
    }

}
