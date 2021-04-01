using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : ObjectController
{
    [Header("Sprites")]
    public Sprite[] imagebox;
    private SpriteRenderer image;

    protected override void Start()
    {
        // a vida da caixa torna-se o numero de sprites
        life = imagebox.Length-1;

        image = GetComponent<SpriteRenderer>();
        
        base.Start();
    }
  
    public override void Takedamage(int dmg)
    {
        life -= dmg;


        if(life>=0) image.sprite = imagebox[life];

        if (life <= 0)
        {
            life = 0;
            Destroy(gameObject, 1.5f);
           
            //anim.SetTrigger("Destroy");
        }
    }
}
