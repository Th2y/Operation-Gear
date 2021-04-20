using UnityEngine;

public class AnimController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private string saveDir = "Down";

    public void IsAttaking()
    {
        anim.SetBool("IsAttaking", true);
    }
    public void IsNotAttaking()
    {
        anim.SetBool("IsAttaking", false);
    }
    public void IsNotMoving()
    {
        anim.SetBool("IsMoving", false);
    }
    public void MoveToDirection(string direcao)
    {
        if (saveDir != null)
        {
            anim.SetBool("IsMoving", true);
            if (saveDir == direcao)
            {
                anim.SetBool(saveDir, true);
            }
            else
            {
                anim.SetBool(direcao, true);
                anim.SetBool(saveDir, false);
                saveDir = direcao;
            }
            Invoke("IsNotMoving",1f);
        }
    }
}
