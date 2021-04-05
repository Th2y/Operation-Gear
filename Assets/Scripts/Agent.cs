using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    [Header("Algoritmo busca")]
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Map map;

    [Header("Movimentação")]
    [SerializeField]
    private float movementDelay;


    private float movementElapsedTime;

    private List<Node> path;
    private Node targetNode;
    private AStar searchAlgorithm;

    private bool searching;


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
        this.targetNode = this.map.GetNodeByPosition(this.target.position);

        this.searchAlgorithm = new AStar(currentNode);
        this.searchAlgorithm.Find(this.targetNode);
        this.path = this.searchAlgorithm.Path;
    }

    private void Update() {
        if (!this.searching) {
            return;
        }
        Node currentTargetNode = this.map.GetNodeByPosition(this.target.position);
        Node previousTargetNode = this.searchAlgorithm.TargetNode;
        if (currentTargetNode != previousTargetNode) {
            FindPath();
        }

        if ((this.path != null) && (this.path.Count > 0)) {
            this.movementElapsedTime += Time.deltaTime;
            if (this.movementElapsedTime >= this.movementDelay) {
                this.movementElapsedTime = 0;

                // Move para o próximo nó e remove o nó do caminho restante
                this.transform.position = this.path[0].Position;
                this.path.RemoveAt(0);                
            }
        }        
    }

    private void OnDrawGizmos() {
        if (this.path != null) {
            Gizmos.color = Color.green;
            Node previousNode = null;
            foreach (Node node in this.path) {                
                Gizmos.DrawSphere(node.Position, 0.1f);
                if (previousNode != null) {
                    Gizmos.DrawLine(previousNode.Position, node.Position);
                }
                previousNode = node;
            }
        }
    }

}
