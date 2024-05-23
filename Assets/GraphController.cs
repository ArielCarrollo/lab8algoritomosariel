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
    public List<GameObject> AllNodes;

    // Start is called before the first frame update
    void Start()
    {
        CreateNodes();
        CreateConections();
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
                AllNodes.Add(tmp);
                //Allnodes.InsertNodeAtStart(tmp);
            }
        }
    }
    void CreateConections()
    {
        if (nodeConectionstxt != null)
        {
            arrayNodeconections = nodeConectionstxt.text.Split('\n');
            for(int i = 0; i < arrayNodeconections.Length; i++)
            {
                currentNodeconections = arrayNodeconections[i].Split(",");
                for(int j = 0; j < currentNodeconections.Length; j++)
                {
                    AllNodes[i].GetComponent<NodeControl>().AddadjacentNodes(AllNodes[int.Parse(currentNodeconections[j])].GetComponent<NodeControl>());
                }
            }
        }
    }
}
