using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public bool Open;
    public GameObject Inventory;
    public Animator anim;
   

    public void OpenBag()
    {

        if (!Open)
        {
            Open = true;
            Inventory.SetActive(Open);
            anim.SetBool("Open",Open);

        }
        else if (Open)
        {
            Open = false;
            Inventory.SetActive(Open);
            anim.SetBool("Open", Open);

        }



    }

}
