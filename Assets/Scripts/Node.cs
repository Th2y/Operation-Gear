using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Node {

    private readonly Vector2 position;
    private readonly bool walkable;
    private readonly List<Node> nextNodes;


    public Node(Vector2 position, bool walkable) {
        this.nextNodes = new List<Node>();
        this.position = position;
        this.walkable = walkable;
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
        float distance = Vector2.Distance(this.Position, node.Position);
        if (distance <= Mathf.Epsilon) {
            return true;
        }
        return false;
    }

    public Node GetNearestNeighbor(Vector2 targetPosition) {
        List<Node> sortedNeighbors = GetNearestNeighbors(targetPosition);
        return sortedNeighbors[0];
    }

    public float GetHeuristic(Node currentNode, Vector2 targetPosition) {
        float distanceToNextNode = Vector2.Distance(currentNode.Position, this.position);
        float distanceToTarget = Vector2.Distance(this.Position, targetPosition);

        return (distanceToNextNode + distanceToTarget);
    }

    public bool IsNeighbor(Node node) {
        foreach (Node neighbor in this.nextNodes) {
            if (neighbor.Equals(node)) {
                return true;
            }
        }
        return false;
    }
}
