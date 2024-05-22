using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    public GameObject nodeprefab;
    public TextAsset nodePositiontxt;
    public string[] arrayNodePositions;
    public string[] CurrentNodePositions;
    //public SimplyLinkedList<GameObject> Allnodes;
    public List<GameObject> AllNodes;

    // Start is called before the first frame update
    void Start()
    {
        if(nodePositiontxt != null)
        {
            arrayNodePositions = nodePositiontxt.text.Split('\n');
            for (int i = 0; i < arrayNodePositions.Length; i++)
            {
                CurrentNodePositions = arrayNodePositions[i].Split(",");
                Vector2 position = new Vector2(float.Parse(CurrentNodePositions[0]), float.Parse(CurrentNodePositions[1]));
                GameObject tmp = Instantiate(nodeprefab, position, transform.rotation);
                AllNodes.Add(tmp);
                //Allnodes.InsertNodeAtEnd(tmp);
            }
        }
    }
}
