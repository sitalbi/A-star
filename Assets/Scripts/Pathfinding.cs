using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private Grid grid;

    public Grid GetGrid() {
        return grid;
    }

    public Pathfinding(int width, int height, Vector3 origin) {
        new Grid(width, height, 10f, origin);
    }

    public List<Node> FindPath(Vector3 start, Vector3 end) {
        Node startNode = grid.GetNode((int)start.x, (int)start.y);
        Node endNode = grid.GetNode((int)end.x, (int)end.y);

        Heap Q = new Heap(grid.width * grid.height);
        Heap P = new Heap(grid.width * grid.height);

        Q.HeapAdd(startNode);

        startNode.gCost = 0;
        startNode.hCost = DistanceHeuristic(startNode, endNode);
        startNode.CalculateScore();

        while (!Q.HeapIsEmpty()) {
            Node u = Q.HeapPop();

            if (u.Equals(endNode)) {
                // return path using parents
                List<Node> path = new List<Node>();
                while(u.parent!=null) {
                    path.Add(u);
                    u = u.parent;
                }
            }

            P.HeapAdd(u);
            foreach(Node node in grid.GetNeighbourList(u)) {
                if(!P.HeapContains(node)) {
                    if(!Q.HeapContains(node)) {
                        Q.HeapAdd(node);
                    } else if(node.gCost<=u.gCost) {
                        node.gCost = u.gCost;
                        node.parent = u;
                        node.CalculateScore();
                    }
                }
            }
        }

        return null;
    }

    private int DistanceHeuristic(Node a, Node b) {
        int xdist = Mathf.Abs(a.x - b.x);
        int ydist = Mathf.Abs(a.y - b.y);
        return Mathf.Abs(xdist - ydist);
    }
}
