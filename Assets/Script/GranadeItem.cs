using System;
using UnityEngine;

public class GranadeItem : MonoBehaviour
{
    public Action Callback { get; set; }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<ThrowGrenadeScript>().IncreaseGranadeCount();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Callback.Invoke();
    }
}
