using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private Grid grid;

    public Grid GetGrid() {
        return grid;
    }

    public Pathfinding(int width, int height) {
        grid = new Grid(width, height, 10f);
    }

    public List<Node> FindPath(int x1, int y1, int x2, int y2) {
        Node startNode = grid.GetNode(x1, y1);
        Node endNode = grid.GetNode(x2, y2);

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
                path.Add(endNode);
                while(u.parent!=null) {
                    path.Add(u.parent);
                    u = u.parent;
                }
                path.Reverse();
                return path;
            }

            P.HeapAdd(u);
            
            foreach(Node node in grid.GetNeighbourList(u)) {
                if (!node.isWalkable) {
                    P.HeapAdd(node);
                }
                if(!P.HeapContains(node)) {
                    int newCost = u.gCost + DistanceCost(u, node);
                    if (newCost < node.gCost) {
                        node.parent = u;
                        node.gCost = newCost;
                        node.hCost = DistanceHeuristic(node, endNode);
                        node.CalculateScore();
                        
                        if(!Q.HeapContains(node)) {
                            Q.HeapAdd(node);
                        }
                    }
                }
            }
        }
        return null;
    }

    private int DistanceCost(Node a, Node b) {
        int xdist = Mathf.Abs(a.x - b.x);
        int ydist = Mathf.Abs(a.y - b.y);
        int r = Mathf.Abs(xdist - ydist);
        return 14 * Mathf.Min(xdist, ydist) + 10 * r;
    }

    private int DistanceHeuristic(Node a, Node b) {
        int xdist = Mathf.Abs(a.x - b.x);
        int ydist = Mathf.Abs(a.y - b.y);
        return Mathf.Abs(xdist - ydist);
    }
}
