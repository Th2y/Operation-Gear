using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    private static readonly Vector2[] Directions = new Vector2[] { 
        Vector2.up, 
        Vector2.right, 
        Vector2.down, 
        Vector2.left 
    };

    [SerializeField]
    private int maxNodes = 500;

    [HideInInspector]
    [SerializeField]
    private List<Node> nodes;

    [HideInInspector]
    [SerializeField]
    private bool baked;

    [SerializeField]
    private LayerMask layerMask;

#if UNITY_EDITOR
    [Header("Debug")]
    private bool drawGizmos;
#endif

    Vector2 startPosition;
    public Transform posOrigem;

#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(startPosition, 0.5f);
        if (this.nodes != null) {
            foreach (Node node in this.nodes) {
                if (node.Walkable) {
                    Gizmos.color = Color.blue;
                } else {
                    Gizmos.color = Color.red;
                }
                Gizmos.DrawSphere(node.Position, 1f);
            }
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(startPosition, 0.5f);
    }
#endif

    public void Bake() {
        this.startPosition = this.posOrigem.TransformPoint(Vector2.zero);
        Debug.Log(this.posOrigem.TransformPoint(Vector2.zero));

        /*this.transform.position = portaConectar.transform.position;
        Vector3 posConectadaGlobal = portaConectada.transform.TransformPoint(Vector3.zero);
        Vector3 distanciaPortas = this.transform.position - posConectadaGlobal;
        this.transform.position += distanciaPortas;*/


        this.nodes = new List<Node>();

        RaycastHit2D hit = Physics2D.Linecast(startPosition, startPosition, this.layerMask);
        Node origin = CreateNode(hit.transform, startPosition);

        FindNextNodes(origin);
#if UNITY_EDITOR
        Debug.Log("[Map]: {Bake} Quantidade de n�s: " + this.nodes.Count);
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
            Debug.LogWarning("[Map]: {FindNextNodes} Mapeamento do cen�rio cancelado por excesso de tiles.");
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
                hit = Physics2D.Linecast(nextNodePosition, nextNodePosition, this.layerMask);
                // Verifica se j� existe um n� na posi��o calculada
                nextNode = GetNodeByPosition(nextNodePosition);
                // Caso o n� ainda n�o exista
                if (nextNode == null) {
                   nextNode = CreateNode(hit.transform, nextNodePosition);
                }

                node.AddNext(nextNode);
                if (nextNode.Walkable || nextNode.Removable) {                    
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

    private Node CreateNode(Transform mapObject, Vector2 nextNodePosition) {
        bool removable;
        bool walkable;
        if (mapObject != null) {
            // C�lula ocupada (n�o pode andar)
            removable = (mapObject.gameObject.layer == LayerMask.NameToLayer("Removable"));
            walkable = false;
        } else {
            // C�lula vazio (pode andar)
            walkable = true;
            removable = false;
        }

        Node node = new Node(nextNodePosition, walkable, removable);
        if (removable) {
            RemovableObject removableObject = mapObject.GetComponent<RemovableObject>();
            if(removableObject != null)
            {
                removableObject.Node = node;
            }
            else
            {
                Debug.LogWarning("Objetos remov�veis devem ter o script RemovableObject.GameObject:"+mapObject.name);
            }
        }

        return node;
    }

}
