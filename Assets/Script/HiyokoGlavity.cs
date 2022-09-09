using System;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class HiyokoGlavity : MonoBehaviour 
{
    public float accelerationScale;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            other.gameObject.GetComponent<Patrol>().enabled = false;
            other.gameObject.GetComponent<RandomMove>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            other.gameObject.GetComponent<Patrol>().enabled = false;
            other.gameObject.GetComponent<RandomMove>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            var direction = gameObject.transform.position - other.gameObject.transform.position;
            direction.Normalize();

            other.GetComponent<Rigidbody>().AddForce(accelerationScale * direction, ForceMode.Acceleration);
        }
    }
}