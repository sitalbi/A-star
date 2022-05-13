using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heap
{
    public Node[] array; // array begins at index 1
    public int n, nmax;
    
    public Heap(int nmax) {
        this.n = 0;
        this.nmax = nmax;
    }

    public int ComparisonFunction(Node a, Node b) {
        return a.score - b.score;
    }

    public void HeapAdd(Node n) {
        // TODO
    }
}
