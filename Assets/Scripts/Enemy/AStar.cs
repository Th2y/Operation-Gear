using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar {

    private Node originNode;
    private Node targetNode;

    private List<Node> visitedNodes;

    private Path path;

    public AStar(Node originNode) {
        this.visitedNodes = new List<Node>();
        this.originNode = originNode;
    }

    public Path Path {
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

        this.path = FindRecursively(this.originNode);
        if ((path != null) && !path.IsEmpty()) {
            this.path = RebuildPath(this.originNode);
            this.path.Remove(this.originNode);
        }
    }

    private Path RebuildPath(Node originNode) {
        Path rebuiltPath = new Path();
        rebuiltPath.Add(this.targetNode);

        Node currentNode = this.targetNode;
        while(currentNode != originNode) {
            // Identifica o nó do caminho que possui
            // a menor distância até o nó atual da iteração,
            // com o objetivo de reduzir o caminho calculado originalmente
            Node nearestNode = null;
            float minDistance = float.MaxValue;
            foreach (Node node in this.path.Nodes) {
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

            rebuiltPath.AddPrevious(nearestNode);
            currentNode = nearestNode;
        }
        return rebuiltPath;
    }

    private Path FindRecursively(Node currentNode) {
        if (visitedNodes == null) {
            visitedNodes = new List<Node>();
        }

        if (this.targetNode != null) {
            if (!visitedNodes.Contains(currentNode)) {
                visitedNodes.Add(currentNode);
                
                if (currentNode == this.targetNode) {
                    Path path = new Path();
                    path.AddPrevious(currentNode);
                    path.Complete();
                    return path;
                }

                List<Path> pathes = new List<Path>();

                List<Node> nextNodes = currentNode.GetNearestNeighbors(this.targetNode.Position);
                foreach (Node nextNode in nextNodes) {
                    if (nextNode.Walkable && !visitedNodes.Contains(nextNode)) {
                        Path path = FindRecursively(nextNode);
                        if ((path != null) && path.IsComplete()) {
                            path.AddPrevious(currentNode);
                            pathes.Add(path);
                        }
                    }
                }

                Path smallestPath = null;
                foreach (Path currentPath in pathes) {
                    if ((smallestPath == null) || (currentPath.GetDistance() < smallestPath.GetDistance())) {
                        smallestPath = currentPath;
                    }
                }
                return smallestPath;
            }
        }
        return null;
    }



}
