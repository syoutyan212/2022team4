using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    void Start()
    {
        Invoke("EffectBoom",10f);
    }

    void EffectBoom()
    {
        Destroy(gameObject);
    }
}