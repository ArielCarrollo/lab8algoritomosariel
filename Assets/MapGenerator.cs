using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Sprite[] Allsprites;
    [SerializeField] private GameObject mapPrefab;
    [SerializeField] private TextAsset maptxt;
    [SerializeField] private string[] AllMapString;
    [SerializeField] private string[] currentLineString;
    [SerializeField] private Vector2 InitialPosition;
    [SerializeField] private float posSeparation;
    // Start is called before the first frame update
    void Awake()
    {
        if(maptxt != null)
        {
            AllMapString = maptxt.text.Split('\n');
            for (int i = 0; i < AllMapString.Length; i++)
            {
                currentLineString = AllMapString[i].Split(",");
                for (int j = 0; j < currentLineString.Length; j++)
                {
                    Vector2 position = new Vector2(InitialPosition.x + posSeparation * j, InitialPosition.y - posSeparation * i);
                    GameObject tmp = Instantiate(mapPrefab, position, transform.rotation);
                    tmp.transform.SetParent(this.gameObject.transform);
                    tmp.GetComponent<partMapControl>().SetSprite(Allsprites[int.Parse(currentLineString[j])]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
