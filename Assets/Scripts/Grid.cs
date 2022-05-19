using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid {
    public int width;
    public int height;
    private float nodeSize;
    private Node[,] gridArray;
    private Tilemap tilemap;

    public Grid(int width, int height, float nodeSize) {
        this.width = width;
        this.height = height;
        this.nodeSize = nodeSize;
        gridArray = new Node[width,height];
        tilemap = GameObject.Find("Grid/Tilemap").GetComponent<Tilemap>();
        

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                /* To use if you want to see the grid on the screen
                    Debug.DrawLine(GetPosition(x, y), GetPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetPosition(x, y), GetPosition(x + 1, y), Color.white, 100f);
                */
                
                // find the non-walkable tile by their name
                bool isWalkable = tilemap.GetTile<Tile>(new Vector3Int(x, y, 0)).name != "wall";
                gridArray[x, y] = new Node(this, x, y, isWalkable);
            }
        }
        /* To use if you want to see the grid on the screen
            Debug.DrawLine(GetPosition(0, height), GetPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetPosition(width, 0), GetPosition(width, height), Color.white, 100f);
        */
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt(worldPosition.x / nodeSize);
        y = Mathf.FloorToInt(worldPosition.y / nodeSize);
    }

    public Vector3 GetPosition(int x, int y) {
        return new Vector3(x, y) * nodeSize;
    }

    public Node GetNode(int x, int y) {
        if((x<width && y<height) && (x>=0 && y>=0)) {
            return gridArray[x, y];
        }
        return null;
    }

    public List<Node> GetNeighboursList(Node node) {
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
}
