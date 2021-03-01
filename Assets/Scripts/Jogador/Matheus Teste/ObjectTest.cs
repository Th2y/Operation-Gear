using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTest : MonoBehaviour
{
    public int life; //vida

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Takedamage(int dmg)
    {
        life-=dmg;
        
        if (life <= 0) Destroy(gameObject);
    }
}
