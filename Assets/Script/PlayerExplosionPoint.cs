using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionPoint : MonoBehaviour
{
    public static readonly int MaxExplosionPoint = 1000;
    public int ExplosionPoint { get; set; }
    
    public void ResetExplosionPoint()
    {
        ExplosionPoint = 0;
    }
}
