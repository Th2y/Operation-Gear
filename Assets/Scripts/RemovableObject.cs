using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RemovableObject : MonoBehaviour {

    private Node node;


    public Node Node {
        set {
            this.node = value;
        }
    }

    public bool Walkable {
        get {
            return this.node.Walkable;
        }
        set {
            this.node.Walkable = value;
        }
    }

}
