using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : RemovableObject
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Walkable = true;
            this.gameObject.SetActive(false);
        }

    }
}
