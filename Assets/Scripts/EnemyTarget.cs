using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public Transform target;
    private bool isFollowing;

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
            this.transform.position = target.position;
        }
    }
}
