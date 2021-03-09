using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            transform.position = new Vector3(rb.position.x + 1, rb.position.y, 0);
        }
        if (Input.GetKeyDown("left"))
        {
            transform.position = new Vector3(rb.position.x - 1, rb.position.y, 0);
        }
        if (Input.GetKeyDown("up"))
        {
            transform.position = new Vector3(rb.position.x, rb.position.y + 1, 0);
        }
        if (Input.GetKeyDown("down"))
        {
            transform.position = new Vector3(rb.position.x, rb.position.y - 1, 0);
        }
    }
}
