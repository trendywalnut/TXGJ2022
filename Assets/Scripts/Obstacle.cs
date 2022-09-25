using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private CarHealth carHealth;

    private void Start()
    {
        carHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CarHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other + " hit");
        if(other.tag == "Player")
        {
            carHealth.TakeDamage(1);
        }
    }
}
