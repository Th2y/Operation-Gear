using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            Move(Vector2.up);
        } else if (Input.GetKeyDown(KeyCode.S)) {
            Move(Vector2.down);
        } else if (Input.GetKeyDown(KeyCode.A)) {
            Move(Vector2.left);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            Move(Vector2.right);
        }
    }

    private void Move(Vector2 direction) {
        Vector2 targetPosition = ((Vector2)this.transform.position + direction);
        RaycastHit2D hit = Physics2D.Linecast(this.transform.position, targetPosition);
        if (hit.transform == null) {
            this.transform.position += (Vector3)direction;
        }
    }

}
