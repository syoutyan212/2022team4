using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    void Start()
    {
        Invoke("EffectBoom",1.5f);
    }

    void EffectBoom()
    {
        Destroy(gameObject);
    }
}