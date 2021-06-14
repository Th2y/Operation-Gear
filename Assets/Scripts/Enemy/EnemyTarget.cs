using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public Transform player;
    private bool isFollowing;
    public Agent agent;

    public void Follow()
    {
        isFollowing = true;
    }

    public void StopFollow()
    {
        isFollowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            if (agent.HasTarget())
            {
                this.transform.position = agent.TargetPosition;
            }
            else
            {
                this.transform.position = player.position;
            }        
        }
    }
}
