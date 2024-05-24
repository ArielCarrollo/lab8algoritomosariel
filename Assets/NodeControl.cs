using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public List<NodeControl> adjacentNode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddadjacentNodes(NodeControl node)
    {
        adjacentNode.Add(node);
    }
    public NodeControl SelectrandomAdjacent()
    {
        int index = Random.Range(0, adjacentNode.Count);
        return adjacentNode[index];
    }
}
