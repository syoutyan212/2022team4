using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTime : MonoBehaviour
{
    public float deleteTime;

    void Start()
    {
        Destroy(gameObject, deleteTime);
    }
}