using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public Grid grid;
    public int x;
    public int y;
    public Node parent;

    public int hCost; // heuristic (distance from end node)
    public int gCost; // distance from start node
    public int score; // hCost + gCost

    public Node(Grid grid, int x, int y) {
        this.x = x;
        this.y = y;
        this.grid = grid;
        this.gCost = int.MaxValue;
        CalculateScore();
        this.parent = null;
    }

    public void CalculateScore() {
        score = hCost + gCost;
    }
}
