using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class GranadeItem : MonoBehaviour
{
    public Action Callback { get; set; }
    private TweenerCore<Vector3, Vector3, VectorOptions> move;

    private void Start()
    {
        move = transform.DOLocalMove(transform.localPosition + Vector3.down, 1.0f).SetLoops(-1, LoopType.Yoyo);
    }

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
        move.Kill();
        Callback.Invoke();
    }
}
