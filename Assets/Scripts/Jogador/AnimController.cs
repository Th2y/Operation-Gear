using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimController : MonoBehaviour
{
    private Animator anim;

    public string saveDir;
    // Start is called before the first frame update
    void Start() 
    {
        saveDir = "Down";
        anim = GetComponent<Animator>();

    }

    public void IsAttaking()
    {
        anim.SetBool("IsAttaking", true);
    }
    public void IsNotAttaking()
    {
        anim.SetBool("IsAttaking", false);
    }
    public void IsMoving()
    {
        anim.SetBool("IsMoving", true);
    }
    public void IsNotMoving()
    {
        anim.SetBool("IsMoving", false);
    }
    public void MoveToDirection(string direcao)
    {

        if (saveDir != null)
        {
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
