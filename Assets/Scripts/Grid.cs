using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    public int width;
    public int height;
    private float nodeSize;
    private Node[,] gridArray;
    private Vector3 originPosition;

    public Grid(int width, int height, float nodeSize, Vector3 originPosition) {
        this.width = width;
        this.height = height;
        this.nodeSize = nodeSize;
        this.gridArray = new Node[width,height];
        this.originPosition = originPosition;
        

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Debug.DrawLine(GetPosition(x, y), GetPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetPosition(x, y), GetPosition(x + 1, y), Color.white, 100f);
                gridArray[x, y] = new Node(this, x, y);
            }
        }
        Debug.DrawLine(GetPosition(0, height), GetPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetPosition(width, 0), GetPosition(width, height), Color.white, 100f);
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y) {
        worldPosition -= originPosition;
        x = Mathf.FloorToInt(worldPosition.x / nodeSize);
        y = Mathf.FloorToInt(worldPosition.y / nodeSize);
    }

    public Vector3 GetPosition(int x, int y) {
        return new Vector3(x, y) * nodeSize + originPosition;
    }

    public Node GetNode(int x, int y) {
        return gridArray[x, y];
    }

    public List<Node> GetNeighbourList(Node node) {
        List<Node> neighbourList = new List<Node>();

        //Left
        if(node.x-1 >= 0) {
            neighbourList.Add(GetNode(node.x-1, node.y));
            if(node.y+1<this.height) {
                neighbourList.Add(GetNode(node.x - 1, node.y + 1));
            }
            if (node.y -1 >= 0) {
                neighbourList.Add(GetNode(node.x - 1, node.y -1));
            }
        }
        //Right
        if(node.x + 1 < this.width) {
            neighbourList.Add(GetNode(node.x + 1, node.y));
            if (node.y + 1 < this.height) {
                neighbourList.Add(GetNode(node.x + 1, node.y + 1));
            }
            if (node.y - 1 >= 0) {
                neighbourList.Add(GetNode(node.x + 1, node.y - 1));
            }
        }
        //Up
        if(node.y - 1 >= 0) {
            neighbourList.Add(GetNode(node.x, node.y - 1));
        }
        //Down
        if (node.y + 1 < this.height) {
            neighbourList.Add(GetNode(node.x, node.y + 1));
        }

        return neighbourList;
    }

    public void SetValue(Vector3 worldPosition, Node value) {
        GetXY(worldPosition, out int x, out int y);
        SetValue(x, y, value);
    }

    public void SetValue(int x, int y, Node value) {
        if (x >= 0 && y >= 0 && x < width && y < height) {
            gridArray[x, y] = value;
        }
    }
}
