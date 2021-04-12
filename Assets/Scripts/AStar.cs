using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar {

    private Node originNode;
    private Node targetNode;

    private List<Node> path;

    public AStar(Node originNode) {
        this.originNode = originNode;
        this.path = new List<Node>();
    }

    public List<Node> Path {
        get {
            return this.path;
        }
    }

    public Node TargetNode {
        get {
            return this.targetNode;
        }
    }

    public void Find(Node targetNode) {
        this.targetNode = targetNode;

        bool pathFound = FindRecursively(this.originNode);
        if (pathFound) {
            this.path = RebuildPath(this.originNode);
            this.path.Remove(this.originNode);
            this.Path.Remove(targetNode);
        }
    }

    private List<Node> RebuildPath(Node originNode) {
        List<Node> rebuiltPath = new List<Node>();
        rebuiltPath.Add(this.targetNode);

        Node currentNode = this.targetNode;
        while(currentNode != originNode) {
            // Identifica o nó do caminho que possui
            // a menor distância até o nó atual da iteração,
            // com o objetivo de reduzir o caminho calculado originalmente
            Node nearestNode = null;
            float minDistance = float.MaxValue;
            foreach (Node node in this.path) {
                if (!rebuiltPath.Contains(node)) {
                    if (node.IsNeighbor(currentNode)) {
                        float distance = node.GetHeuristic(currentNode, originNode.Position);
                        if ((nearestNode == null) || (distance < minDistance)) {
                            nearestNode = node;
                            minDistance = distance;
                        }
                    }
                }
            }

            if (nearestNode == null) {
                int currentNodexIndex = this.path.IndexOf(currentNode);
                Node previousNode = this.path[(currentNodexIndex - 1)];
                currentNode = previousNode;
            } else {
                rebuiltPath.Insert(0, nearestNode);
                currentNode = nearestNode;
            }
        }
        return rebuiltPath;
    }

    private bool FindRecursively(Node currentNode) {
        if (!this.path.Contains(currentNode)) {
            this.path.Add(currentNode);

            if (currentNode == this.targetNode) {
                return true;
            }

            if (this.targetNode != null) {
                List<Node> nextNodes = currentNode.GetNearestNeighbors(this.targetNode.Position);
                foreach (Node nextNode in nextNodes) {
                    if (nextNode.Walkable && !this.path.Contains(nextNode)) {
                        bool found = FindRecursively(nextNode);
                        if (found) {
                            return true;
                        } else {
                            this.path.Remove(nextNode);
                        }
                    }
                }
            }
        }
        return false;
    }



}
