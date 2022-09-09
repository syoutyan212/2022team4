using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    private Button _button;
    private Image fade;
    private TitleAudio _titleAudio;
    private Coroutine _coroutine;

    private void Start()
    {
        _button = GetComponent<Button>();
        fade = GameObject.Find("FadeCanvas").GetComponentInChildren<Image>();
        _titleAudio = GameObject.Find("Audio").GetComponent<TitleAudio>();
    }

    public void OnClick()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(OnClickRoutine());
        }
    }

    private IEnumerator OnClickRoutine()
    {
        _button.interactable = false;
        fade.raycastTarget = true;
        _titleAudio.ShotGameStartSound();
        yield return fade.DOFade(1.0f, 1.0f).WaitForCompletion();
    }
}
