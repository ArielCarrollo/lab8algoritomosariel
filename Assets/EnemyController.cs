using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject objetive;
    public Vector2 SpeedReference;
    public int energy = 100; // Agregamos una variable de energía
    public bool isResting = false; // Agregamos un estado de descanso

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isResting) // Si el enemigo no está descansando
        {
            transform.position = Vector2.SmoothDamp(transform.position, objetive.transform.position, ref SpeedReference, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            energy -= collision.gameObject.GetComponent<NodeControl>().nodeWeight; // Restamos la energía del enemigo
            if (energy <= 0) // Si la energía del enemigo es 0 o menos
            {
                StartCoroutine(Rest()); // El enemigo descansa
            }
            else
            {
                objetive = collision.gameObject.GetComponent<NodeControl>().SelectrandomAdjacent().gameObject;
            }
        }
    }

    IEnumerator Rest() // Corrutina para descansar
    {
        isResting = true;
        yield return new WaitForSeconds(5); // Descansa durante 5 segundos
        energy = 100; // Recupera toda su energía
        isResting = false;
        objetive = objetive.GetComponent<NodeControl>().SelectrandomAdjacent().gameObject; // Selecciona un nuevo objetivo después de descansar
    }
}

