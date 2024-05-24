using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject objetive;
    public Vector2 SpeedReference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, objetive.transform.position, ref SpeedReference, 0.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            objetive = collision.gameObject.GetComponent<NodeControl>().SelectrandomAdjacent().gameObject;
        }
    }
}
