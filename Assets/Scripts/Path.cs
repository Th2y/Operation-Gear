using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path {


    private readonly List<Node> nodes;
    private bool complete;


    public Path() {
        this.nodes = new List<Node>();
        this.complete = false;
    }

    public List<Node> Nodes {
        get {
            return this.nodes;
        }
    }

    public Node GetNext() {
        if (this.nodes.Count > 0) {
            Node nextNode = this.nodes[0];
            Remove(nextNode);
            return nextNode;
        }
        return null;
    }

    public void Add(Node node) {
        if (!this.nodes.Contains(node)) {
            this.nodes.Add(node);
        }
    }

    public void AddPrevious(Node node) {
        if (!this.nodes.Contains(node)) {
            this.nodes.Insert(0, node);
        }
    }

    public void Remove(Node node) {
        if (this.nodes.Contains(node)) {
            this.nodes.Remove(node);
        }
    }

    public bool Contains(Node node) {
        return this.nodes.Contains(node);
    }

    public void Complete() {
        this.complete = true;
    }

    public bool IsComplete() {
        return this.complete;
    }

    public bool IsEmpty() {
        return (this.nodes.Count == 0);
    }

    public int NodeCount {
        get {
            return this.nodes.Count;
        }
    }

    public float GetDistance() {
        if (this.nodes.Count > 0) {
            float distance = 0;
            Node currentNode = null;
            foreach (Node node in this.nodes) {
                if (currentNode != null) {
                    distance += currentNode.GetDistanceTo(node);
                }
                currentNode = node;
            }
            return distance;
        }
        return 0;
    }
    
}
