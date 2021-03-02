using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey("up"))
        {
            transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey("down"))
        {
            transform.position += new Vector3(0, -speed, 0);
        }
    }
}
