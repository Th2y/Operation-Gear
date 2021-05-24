using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private Agent agent;
    [SerializeField]
    private Map map;

    public void Iniciar()
    {
        map.Bake();
        agent.Init();
    }

    // Update is called once per frame

}
