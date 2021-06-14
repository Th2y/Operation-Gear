using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIndicator : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    

    public void Show(Vector2 enemyPosition,Vector2[] positions)
    {
        this.gameObject.SetActive(true);
        this.transform.position = enemyPosition;
        this.lineRenderer.SetPosition(0, Vector2.zero);
        int index = 1;
        foreach(Vector2 position in positions)
        {
            this.lineRenderer.SetPosition(index, new Vector2(position.x - enemyPosition.x, position.y - enemyPosition.y));
            index++;
        }
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
