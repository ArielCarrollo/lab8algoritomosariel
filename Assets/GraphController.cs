using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    public GameObject nodeprefab;
    public TextAsset nodePositiontxt;
    public string[] arrayNodePositions;
    public string[] CurrentNodePositions;
    public TextAsset nodeConectionstxt;
    public string[] arrayNodeconections;
    public string[] currentNodeconections;
    public ListaInventadaPropia<GameObject> AllNodes;

    public EnemyController enemy;

    // Start is called before the first frame update
    void Awake()
    {
        AllNodes = new ListaInventadaPropia<GameObject>(); 
        CreateNodes();
        CreateConections();
        SelectinitialNode();
    }

    void CreateNodes()
    {
        if (nodePositiontxt != null)
        {
            arrayNodePositions = nodePositiontxt.text.Split('\n');
            for (int i = 0; i < arrayNodePositions.Length; i++)
            {
                CurrentNodePositions = arrayNodePositions[i].Split(",");
                Vector2 position = new Vector2(float.Parse(CurrentNodePositions[0]), float.Parse(CurrentNodePositions[1]));
                int weight = int.Parse(CurrentNodePositions[2]); // El peso se asigna desde el graphGen.
                GameObject tmp = Instantiate(nodeprefab, position, transform.rotation);
                NodeControl nodeControl = tmp.GetComponent<NodeControl>();
                nodeControl.nodeWeight = weight; // Asignar el peso al nodo
                AllNodes.InsertNodeAtEnd(tmp);
            }
        }
    }

    void CreateConections()
    {
        if (nodeConectionstxt != null)
        {
            arrayNodeconections = nodeConectionstxt.text.Split('\n');
            for (int i = 0; i < arrayNodeconections.Length; i++)
            {
                currentNodeconections = arrayNodeconections[i].Split(",");
                for (int j = 0; j < currentNodeconections.Length; j++)
                {
                    GameObject currentNode = AllNodes.ObtainNodeAtPosition(i);
                    GameObject adjacentNode = AllNodes.ObtainNodeAtPosition(int.Parse(currentNodeconections[j]));
                    currentNode.GetComponent<NodeControl>().AddadjacentNodes(adjacentNode.GetComponent<NodeControl>());
                }
            }
        }
    }

    void SelectinitialNode()
    {
        int index = Random.Range(0, AllNodes.Length);
        enemy.objetive = AllNodes.ObtainNodeAtPosition(index).gameObject; // Accede al gameObject del nodo
    }
}

