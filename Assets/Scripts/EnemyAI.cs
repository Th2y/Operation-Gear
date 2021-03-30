using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    private float timer = 0f;
    public float time;

    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        if (timer >= time)
        {

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

            float distanceX = Mathf.Abs(rb.position.x - path.vectorPath[currentWaypoint].x);

            float distanceY = Mathf.Abs(rb.position.y - path.vectorPath[currentWaypoint].y);



            if (distanceX > distanceY)
            {
                if (direction.x > 0)
                {
                    transform.position = new Vector3(rb.position.x + 1, rb.position.y, 0);
                }
                else if (direction.x < 0)
                {
                    transform.position = new Vector3(rb.position.x - 1, rb.position.y, 0);
                }
            }
            else
            {
                if (direction.y > 0)
                {
                    transform.position = new Vector3(rb.position.x, rb.position.y + 1, 0);
                }
                else if (direction.y < 0)
                {
                    transform.position = new Vector3(rb.position.x, rb.position.y - 1, 0);
                }
            }

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            if (direction.x >= 0.01f)
            {
                enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (direction.x <= -0.01f)
            {
                enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            }

            timer = 0;

        }
        
    }
}
