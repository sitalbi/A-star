using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private Grid grid;

    public Pathfinding(int width, int height, Vector3 origin) {
        new Grid(width, height, 10f, origin);
    }

    public List<Node> FindPath(Vector3 start, Vector3 end) {
        Node startNode = grid.GetNode((int)start.x, (int)start.y);
        Node endNode = grid.GetNode((int)end.x, (int)end.y);

        List<Node> Q = new List<Node>();
        List<Node> P = new List<Node>();

        Q.Add(startNode);

        startNode.gCost = 0;
        startNode.hCost = DistanceHeuristic(startNode, endNode);
        startNode.CalculateScore();

        while(Q.Count > 0) {
            
        }

        return null;
    }

    private int DistanceHeuristic(Node a, Node b) {
        int xdist = Mathf.Abs(a.x - b.x);
        int ydist = Mathf.Abs(a.y - b.y);
        return Mathf.Abs(xdist - ydist);
    }
}
