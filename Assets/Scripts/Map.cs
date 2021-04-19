using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public Vector2 OriginPosition = new Vector2(0.5f, 0.5f);
    private static readonly Vector2[] Directions = new Vector2[] { 
        Vector2.up, 
        Vector2.right, 
        Vector2.down, 
        Vector2.left 
    };

    [SerializeField]
    private int maxNodes = 1000;

    [HideInInspector]
    [SerializeField]
    private List<Node> nodes;

    [HideInInspector]
    [SerializeField]
    private bool baked;

    [SerializeField]
    private LayerMask obstacleLayer;

#if UNITY_EDITOR
    [Header("Debug")]
    private bool drawGizmos;
#endif


#if UNITY_EDITOR
    private void OnDrawGizmos() {
        if (this.nodes != null) {
            foreach (Node node in this.nodes) {
                if (node.Walkable) {
                    Gizmos.color = Color.blue;
                } else {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawSphere(node.Position, 0.1f);
            }
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(OriginPosition, 0.5f);
    }
#endif

    public void Bake() {
        Vector2 startPosition = OriginPosition;
        this.nodes = new List<Node>();

        RaycastHit2D hit = Physics2D.Linecast(startPosition, startPosition, this.obstacleLayer);
        bool walkable;
        if (hit.transform != null) {
            walkable = false;
        } else {
            walkable = true;
        }
        Node origin = new Node(startPosition, walkable);
        FindNextNodes(origin);
#if UNITY_EDITOR
        Debug.Log("[Map]: {Bake} Quantidade de nós: " + this.nodes.Count);
#endif
        this.baked = true;
    }

    public bool Baked {
        get {
            return this.baked;
        }
    }

    public Node GetNodeByPosition(Vector2 position) {
        foreach (Node node in this.nodes) {
            if (node.Position == position) {
                return node;
            }
        }
        return null;
    }

    private void FindNextNodes(Node node) {
        if (this.nodes.Count >= maxNodes) {
#if UNITY_EDITOR
            Debug.LogWarning("[Map]: {FindNextNodes} Mapeamento do cenário cancelado por excesso de tiles.");
#endif
            return;
        }

        if (!ContainsNode(node)) {
            AddNode(node);
            Node nextNode;
            Vector2 nextNodePosition;
            RaycastHit2D hit;
            foreach (Vector2 direction in Directions) {
                nextNodePosition = (node.Position + direction);
                hit = Physics2D.Linecast(nextNodePosition, nextNodePosition, this.obstacleLayer);
                // Verifica se já existe um nó na posição calculada
                nextNode = GetNodeByPosition(nextNodePosition);
                // Caso o nó ainda não exista
                if (nextNode == null) {
                    if (hit.transform != null) {
                        // Célula ocupada (não pode andar)
                        nextNode = new Node(nextNodePosition, false);
                    } else {
                        // Célula vazio (pode andar)
                        nextNode = new Node(nextNodePosition, true);
                    }
                }

                node.AddNext(nextNode);
                if (nextNode.Walkable) {
                    FindNextNodes(nextNode);
                }
            }
        }
    }

    private bool ContainsNode(Node node) {
        foreach (Node existingNode in this.nodes) {
            if (existingNode.Equals(node)) {
                return true;
            }
        }
        return false;
    }

    private void AddNode(Node node) {
        if (!ContainsNode(node)) {
            this.nodes.Add(node);
        }
    }

}
