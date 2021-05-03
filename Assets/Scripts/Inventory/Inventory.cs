using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Mais de uma instancia encontrada");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 20;

    public List<Item> items = new List<Item>();


    public bool AddItem(Item _item)
    {
        if (!_item.isDefaultItem)
        {
            if (items.Count >= space)
            {

                return false;
            }

            items.Add(_item);
         



            if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke();
            }
        }
        return true;
    }

    public void RemoveItem(Item _item, int idSlot)
    {

        if (items.Contains(_item))
        {
            items.Remove(_item);
        }
        else
        {
            Debug.Log(" não tem este item");
        }

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }
   
}
