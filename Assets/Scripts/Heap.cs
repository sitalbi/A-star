using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heap
{
    private Node[] array; // array begins at index 1
    private int n, nmax; // n: number of Node in the heap; nmax: maximum of Node that can be added to the heap
    
    public Heap(int nmax) {
        this.n = 0;
        this.nmax = nmax;
        array = new Node[nmax];
    }

    public int ComparisonFunction(Node a, Node b) {
        return a.score - b.score;
    }
    
    /**
     *  Add a Node to the heap
    */
    public void HeapAdd(Node node) {
        if(n+1<nmax) {
            n++;
            array[n] = node;

            int k = n;
            while (k>1 && ComparisonFunction(node, array[((int)(k/2))]) < 0) {
                //swap
                (array[k], array[k/2]) = (array[k/2], array[k]);
                k /= 2;
            }
        }
    }

    private Node GetHeapTop() {
        return array[1];
    }

    /**
     * Return the root and remove it from the heap
    */ 
    public Node HeapPop() {
        Node top = GetHeapTop();
        array[1] = array[this.n];
        this.n--;
        int i = 1;
        while (i<(n/2)+1) {
            Node tmp = array[i];
            //swap
            if (ComparisonFunction(array[2 * i], array[(2 * i) + 1]) < 0) {
                array[i] = array[i * 2];
                array[i * 2] = tmp;
                i *= 2;
            } else {
                array[i] = array[(i * 2) + 1];
                array[(i * 2) + 1] = tmp;
                i = (i * 2) + 1;
            }
        }
        return top;
    }

    /**
     * Check if the heap is empty 
    */
    public bool HeapIsEmpty() {
        return n == 0;
    }

    public bool HeapContains(Node node) {
        for(int i = 1; i<n; i++) {
            if(array[i].Equals(node)) {
                return true;
            }
        }
        return false;
    }
}
