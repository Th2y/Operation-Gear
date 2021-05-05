using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class Node {

    
    private Vector2 position;

    
    private bool walkable;

    
    private bool removable;

    private List<Node> nextNodes;





    public Node(Vector2 position, bool walkable, bool removable) {
        this.nextNodes = new List<Node>();
        this.position = position;
        this.walkable = walkable;
        this.removable = removable;
    }

    public Vector2 Position {
        get {
            return this.position;
        }
    }

    public bool Walkable {
        get {
            return this.walkable;
        }
        set {
            this.walkable = value;
        }
    }

    public bool Removable {
        get {
            return this.removable;
        }
    }

    public List<Node> NextNodes {
        get {
            return this.nextNodes;
        }
    }

    public List<Node> GetNearestNeighbors(Vector2 targetPosition) {
        return this.nextNodes.OrderBy(node => node.GetHeuristic(this, targetPosition)).ToList();
    }

    public void AddNext(Node node) {
        this.nextNodes.Add(node);
    }


    public bool Equals(Node node) {
        if (node != null) {
            float distance = Vector2.Distance(this.Position, node.Position);
            if (distance <= Mathf.Epsilon) {
                return true;
            }
        }
        return false;
    }

    public Node GetNearestNeighbor(Vector2 targetPosition) {
        List<Node> sortedNeighbors = GetNearestNeighbors(targetPosition);
        return sortedNeighbors[0];
    }

    public float GetHeuristic(Node currentNode, Vector2 targetPosition) {
        float distanceToNextNode = GetDistanceTo(currentNode);
        float distanceToTarget = GetDistanceTo(targetPosition);

        return (distanceToNextNode + distanceToTarget);
    }

    public float GetDistanceTo(Node node) {
        return GetDistanceTo(node.Position);
    }

    public float GetDistanceTo(Vector2 nodePosition) {
        float distanceX = Mathf.Abs(this.position.x - nodePosition.x);
        float distanceY = Mathf.Abs(this.position.y - nodePosition.y);
        //return Vector2.Distance(this.position, nodePosition);
        return (distanceX + distanceY);
    }

    public bool IsNeighbor(Node node) {
        foreach (Node neighbor in this.nextNodes) {
            if (neighbor.Equals(node)) {
                return true;
            }
        }
        return false;
    }

    public override string ToString() {
        return ("[Node "  + this.position.x + "x" + this.position.y + "]");
    }
}
