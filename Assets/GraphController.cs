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
    //public SimplyLinkedList<GameObject> Allnodes;
    public ListaInventadaPropia<GameObject> AllNodes; // Cambio aquí

    public EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        AllNodes = new ListaInventadaPropia<GameObject>(); // Nueva instancia de tu lista
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
                GameObject tmp = Instantiate(nodeprefab, position, transform.rotation);
                AllNodes.InsertNodeAtEnd(tmp); // Cambio aquí
                //Allnodes.InsertNodeAtStart(tmp);
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
                    currentNode.GetComponent<NodeControl>().AddadjacentNodes(adjacentNode.GetComponent<NodeControl>()); // Cambio aquí
                }
            }
        }
    }
    void SelectinitialNode()
    {
        int index = Random.Range(0, AllNodes.length);
        enemy.objetive = AllNodes.ObtainNodeAtPosition(index).gameObject; // Accede al gameObject del nodo
    }
}
