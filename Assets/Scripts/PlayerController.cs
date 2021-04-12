using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float timer;
    private float time;
    public int distanceKnockback;

    private bool isPushing;

    private Rigidbody2D rb;

    public GameObject enemy;

    private Vector2 pushTargetPosition;
    private Vector2 pushDirection;

    public LayerMask collisionLayers;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isPushing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPushing)
        {
            if (Input.GetKeyDown("right"))
            {
                rb.position = new Vector3(rb.position.x + 1, rb.position.y, 0);
            }
            if (Input.GetKeyDown("left"))
            {
                rb.position = new Vector3(rb.position.x - 1, rb.position.y, 0);
            }
            if (Input.GetKeyDown("up"))
            {
                rb.position = new Vector3(rb.position.x, rb.position.y + 1, 0);
            }
            if (Input.GetKeyDown("down"))
            {
                rb.position = new Vector3(rb.position.x, rb.position.y - 1, 0);
            }
        }
        else
        {
            float distance = Vector3.Distance(this.transform.position, pushTargetPosition);
            Debug.Log(distance);
            if (distance < 1)
            {
                isPushing = false;
                Debug.Log("Desativou o Push");
            }
            else
            {
                time += Time.deltaTime;

                if (time >= timer)
                {
                    time = 0;
                 
                    this.transform.position += (Vector3)pushDirection;

                }
            }            
            
        }

    }

    public void Knockback(Vector2 direction)
    {
        isPushing = true;

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, distanceKnockback, collisionLayers);

        float distance;

        if(hit.transform != null)
        {
            distance = Mathf.FloorToInt(hit.distance);
            distance = Mathf.Max(distance, 0);
        }
        else
        {
            distance = distanceKnockback;
        }

        Debug.Log(distance);

        pushTargetPosition = (Vector2)this.transform.position + (direction * distance);

        this.pushDirection = direction;
       
    }
}
