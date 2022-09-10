using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class GranadeItem : MonoBehaviour
{
    public Action Callback { get; set; }
    private TweenerCore<Vector3, Vector3, VectorOptions> move;
    public GameObject ItemEffect;
    private AudioSource _audioSource;
    AudioClip clip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        clip = _audioSource.clip;
        GenerateEffect();
        move = transform.DOLocalMove(transform.localPosition + Vector3.down, 1.0f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(clip);
            other.GetComponentInChildren<ThrowGrenadeScript>().IncreaseGranadeCount();
            Destroy(gameObject, clip.length);
        }
    }
    
    void GenerateEffect()
    {
        GameObject effect = Instantiate(ItemEffect);
        effect.transform.position = gameObject.transform.position;
    }

    private void OnDestroy()
    {
        move.Kill();
        Callback.Invoke();
    }
}
