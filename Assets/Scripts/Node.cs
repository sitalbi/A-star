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
    public bool isWalkable;

    public Node(Grid grid, int x, int y, bool isWalkable) {
        this.x = x;
        this.y = y;
        this.grid = grid;
        this.gCost = int.MaxValue;
        CalculateScore();
        this.parent = null;
        this.isWalkable = isWalkable;
    }

    public void CalculateScore() {
        score = hCost + gCost;
    }

     //Override the Equals function
     public override bool Equals(object obj) {
        // If the passed object is null
        if (obj == null) {
            return false;
        }
        if (!(obj is Node)) {
            return false;
        }
        return (this.x == ((Node)obj).x)
            && (this.y == ((Node)obj).y);
    }
}

