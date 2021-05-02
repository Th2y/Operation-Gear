using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public int life; //vida

    [SerializeField]
    protected Animator anim;

    public virtual void Takedamage(int dmg)
    {
        life -= dmg;

        if (life <= 0)
        {
            Destroy(gameObject, 1.5f);
            
        }
    }
}
