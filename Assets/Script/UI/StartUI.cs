using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] private AudioClip youi;
    [SerializeField] private AudioClip don;
    private AudioSource _audioSource;
    private Text _text;
    private Image fade;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _text = GetComponentInChildren<Text>();
        fade = GameObject.Find("FadeCanvas").GetComponentInChildren<Image>();
        fade.color = Color.black;
        fade.raycastTarget = true;
        StartCoroutine(StartRoutine());
    }

    private IEnumerator StartRoutine()
    {
        yield return fade.DOFade(0.0f, 1.0f).WaitForCompletion();
        fade.raycastTarget = false;
        _text.text = "よ〜い...";
        _audioSource.PlayOneShot(youi);
        yield return _text.rectTransform.DOScale(Vector3.one, 2.0f).WaitForCompletion();
        _audioSource.PlayOneShot(don);
        _text.text = "DON!!";
        yield return _text.rectTransform.DOScale(Vector3.one * 2,  0.2f).WaitForCompletion();
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
