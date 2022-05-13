using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    private int width;
    private int height;
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
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                gridArray[x, y] = new Node(this, x, y);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        worldPosition -= originPosition;
        x = Mathf.FloorToInt(worldPosition.x / nodeSize);
        y = Mathf.FloorToInt(worldPosition.y / nodeSize);
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * nodeSize + originPosition;
    }

    public Node GetNode(int x, int y) {
        return gridArray[x, y];
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
