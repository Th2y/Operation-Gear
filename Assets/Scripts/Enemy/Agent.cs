using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    [Header("Algoritmo busca")]
    private Transform target;

    [SerializeField]
    private Map map;

    [Header("Movimentação")]
    [SerializeField]
    private float movementDelay;


    private float movementElapsedTime;

    private Path path;
    private Node targetNode;
    private AStar searchAlgorithm;

    private bool searching;

    private IAgentObserver observer;

    public IAgentObserver Observer
    {
        set
        {
            this.observer = value;
        }
    }

    public void Init() {
        this.searching = false;
        this.path = null;
        this.targetNode = null;
        this.movementElapsedTime = 0;
        FindPath();
        Resume();
    }

    public void Resume() {
        this.searching = true;
    }

    public void Stop() {
        this.searching = false;
    }

    public Transform Target {
        get {
            return this.target;
        }
        set {
            this.target = value;
        }
    }

    public Vector3 TargetPosition
    {
        get
        {
            return this.targetNode.Position;
        }
    }

    public bool HasTarget()
    {
        return this.targetNode != null;
    }

    public Map Map {
        get {
            return this.map;
        }
        set {
            this.map = value;
        }
    }

    public Vector2 Position {
        get {
            return this.transform.position;
        }
    }

    public float MovementDelay {
        get {
            return this.movementDelay;
        }
        set {
            this.movementDelay = value;
        }
    }

    private void FindPath() {      
        Node currentNode = this.map.GetNodeByPosition(this.transform.position);
        this.searchAlgorithm = new AStar(currentNode);
        if(this.target != null)
        {
            this.targetNode = this.map.GetNodeByPosition(this.target.position);
            this.searchAlgorithm.Find(this.targetNode);
            this.path = this.searchAlgorithm.Path;
        }
        
    }

    private void Update() {
        //Debug.Log(this.searching);
        if (!this.searching || this.target == null) {
            return;
        }
        Node currentTargetNode = this.map.GetNodeByPosition(this.target.position);
        Node previousTargetNode = this.searchAlgorithm.TargetNode;
        //Debug.Log(currentTargetNode);
        //Debug.Log(previousTargetNode);
        if (currentTargetNode != previousTargetNode) {
            //Debug.Log("Estou");
            FindPath();
        }

        if ((this.path != null) && (this.path.NodeCount > 0)) {
            this.movementElapsedTime += Time.deltaTime;
            if (this.movementElapsedTime >= this.movementDelay) {
                this.movementElapsedTime = 0;

                // Move para o próximo nó e remove o nó do caminho restante
                Node nextNode = this.path.GetNext();
                this.transform.position = nextNode.Position;
                if(this.observer != null)
                {
                    this.observer.OnMoveComplete();
                }
            }

        }        
    }

    private void OnDrawGizmos() {
        if (this.path != null) {
            Gizmos.color = Color.green;
            Node previousNode = null;
            foreach (Node node in this.path.Nodes) {                
                Gizmos.DrawSphere(node.Position, 0.1f);
                if (previousNode != null) {
                    Gizmos.DrawLine(previousNode.Position, node.Position);
                }
                previousNode = node;
            }
        }
    }

    public Vector2[] GetNodesPositions()
    {
        if(this.path != null)
        {
            return this.path.GetNodesPositions();
        }
        return null;
    }

}