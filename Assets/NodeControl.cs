using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public ListaInventadaPropia<NodeControl> adjacentNode;
    public int nodeWeight; // Peso del nodo

    // Start is called before the first frame update
    void Awake()
    {
        adjacentNode = new ListaInventadaPropia<NodeControl>();
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
        int index = Random.Range(0, adjacentNode.Length);
        return adjacentNode.ObtainNodeAtPosition(index);
    }
}


