using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject objetive;
    public Vector2 SpeedReference;
    public int energy = 100; 
    public bool isResting = false;
    private GameObject lastVisitedNode;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isResting) 
        {
            transform.position = Vector2.SmoothDamp(transform.position, objetive.transform.position, ref SpeedReference, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            energy -= collision.gameObject.GetComponent<NodeControl>().nodeWeight; 
            if (energy <= 0) 
            {
                StartCoroutine(Rest()); 
            }
            else
            {
                objetive = collision.gameObject.GetComponent<NodeControl>().SelectrandomAdjacent().gameObject;
            }
        }
    }

    IEnumerator Rest() 
    {
        isResting = true;
        yield return new WaitForSeconds(5); 
        energy = 100;
        isResting = false;
        objetive = objetive.GetComponent<NodeControl>().SelectrandomAdjacent().gameObject; 
    }
}

