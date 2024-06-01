using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject objetive;
    public GameObject previousNode;
    public Vector2 SpeedReference;
    public int energy = 100;
    public bool isResting = false;
    public GameObject visionCone; 
    public GameObject player;

    private bool isChasingPlayer = false;
    private float timeSinceLastFrame = 0f;
    public float energyLossRate = 5f; 

    void Update()
    {
        if (isResting) 
        { 
            return; 
        }
        timeSinceLastFrame += Time.deltaTime;
        if (isChasingPlayer && player != null)
        {
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position, ref SpeedReference, 0.5f);
            float energyLoss = energyLossRate * timeSinceLastFrame;
            energy -= Mathf.RoundToInt(energyLoss); 
            if (energy <= 0)
            {
                StartCoroutine(Rest());
            }
        }
        else
        {
            MoveTowardsObjective();
        }
        UpdateVisionCone();
        timeSinceLastFrame = 0f;
    }
    private void MoveTowardsObjective()
    {
        transform.position = Vector2.SmoothDamp(transform.position, objetive.transform.position, ref SpeedReference, 0.5f);
    }
    private void UpdateVisionCone()
    {
        if (visionCone != null)
        {
            Vector2 direction = (Vector2)(objetive.transform.position - transform.position);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            visionCone.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    public void StartChasingPlayer(GameObject player)
    {
        isChasingPlayer = true;
        this.player = player;
    }
    public void StopChasingPlayer()
    {
        isChasingPlayer = false;
        this.player = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            NodeControl currentNode = collision.gameObject.GetComponent<NodeControl>();
            energy -= currentNode.nodeWeight;
            if (energy <= 0)
            {
                StartCoroutine(Rest());
            }
            else
            {
                GameObject nextNode = currentNode.SelectrandomAdjacent().gameObject;
                while (nextNode == previousNode)
                {
                    nextNode = currentNode.SelectrandomAdjacent().gameObject;
                }
                objetive = nextNode;
                previousNode = collision.gameObject;
            }
        }
    }
    IEnumerator Rest() 
    {
        isResting = true;
        yield return new WaitForSeconds(5); 
        energy = 100; 
        isResting = false;
        GameObject nextNode = objetive.GetComponent<NodeControl>().SelectrandomAdjacent().gameObject;
        while (nextNode == previousNode)
        {
            nextNode = objetive.GetComponent<NodeControl>().SelectrandomAdjacent().gameObject;
        }
        objetive = nextNode;
        previousNode = objetive;
    }
}




