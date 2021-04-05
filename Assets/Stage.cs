using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private Agent agent;
    [SerializeField]
    private Map map;

    // Start is called before the first frame update
    void Start()
    {
        map.Bake();
        agent.Init();
    }

    // Update is called once per frame

}
