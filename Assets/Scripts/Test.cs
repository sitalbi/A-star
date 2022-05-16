using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Pathfinding pathfinding;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        pathfinding = new Pathfinding(10, 10, new Vector3(0,0));
        startPosition = new Vector3(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 endPosition = pathfinding.GetGrid().GetPosition((int)mousePos.x, (int)mousePos.y);
            List<Node> path = pathfinding.FindPath(startPosition, endPosition);
            if(path!=null) {
                for(int i = 0; i<path.Count-1;i++) {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y));
                }
            }
        }
    }
}
