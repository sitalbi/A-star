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
        pathfinding = new Pathfinding(10, 10);
        startPosition = new Vector3(0, 0);
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
                    Debug.Log(path.Count);
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 100f);
                }
            }
        }
    }
    
    // Get Mouse position 
    public Vector3 GetMouseWorldPosition() {
        Vector3 pos = GetMouse3DWorldPosition(Input.mousePosition, Camera.main);
        pos.z = 0f;
        return pos;
    }

    private Vector3 GetMouse3DWorldPosition(Vector3 screenPosition, Camera camera) {
        Vector3 worldPosition = camera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
