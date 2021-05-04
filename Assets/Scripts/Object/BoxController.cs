using UnityEngine;

public class BoxController : ObjectController
{
    [Header("Sprites")]

    [SerializeField]
    private Sprite[] imagebox;
    [SerializeField]
    private SpriteRenderer image;

    private void Start()
    {
        // a vida da caixa torna-se o numero de sprites
        life = imagebox.Length-1;
    }
  
    public override void Takedamage(int dmg)
    {
        /*life = 0;

        anim.SetTrigger("Destroy");
        Destroy(gameObject, 1.5f);*/

        life -= dmg;

        /*if(life>0) image.sprite = imagebox[life];

        else
        {
            image.sprite = imagebox[life];
            Destroy(gameObject, 1.5f);
        }*/

        anim.SetInteger("Vidas", life);

        if (life <= 0)
            Destroy(gameObject, 1.5f);
    }
}
