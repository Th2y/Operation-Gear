using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public int life; //vida

    protected Animator anim;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void Takedamage(int dmg)
    {
        life -= dmg;

        if (life <= 0)
        {
            Destroy(gameObject, 1.5f);
            
        }
    }
}
