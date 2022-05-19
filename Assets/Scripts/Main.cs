using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private Pathfinding pathfinding;

    // Start is called before the first frame update
    void Start()
    {
        pathfinding = new Pathfinding(10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mousePos, out int x, out int y);
            List<Node> path = pathfinding.FindPath(0, 0, x, y);
            if(path!=null) {
                for(int i = 0; i<path.Count-1;i++) {
                    // Draw the result path
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.red,  5f);
                }
            }
        }
    }
    
    // Get Mouse position 
    public Vector3 GetMouseWorldPosition() {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        return position;
    }
}
