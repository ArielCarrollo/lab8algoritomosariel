using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public ListaInventadaPropia<NodeControl> adjacentNode;
    public int nodeWeight; // Agregamos un peso al nodo

    // Start is called before the first frame update
    void Start()
    {
        adjacentNode = new ListaInventadaPropia<NodeControl>(); 
        nodeWeight = Random.Range(1, 10); // Asignamos un peso aleatorio al nodo
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddadjacentNodes(NodeControl node)
    {
        adjacentNode.InsertNodeAtEnd(node);
    }

public NodeControl SelectrandomAdjacent()
    {
        int index = Random.Range(0, adjacentNode.length);
        return adjacentNode.ObtainNodeAtPosition(index);
    }
}

