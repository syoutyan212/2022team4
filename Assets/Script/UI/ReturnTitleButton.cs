using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnTitleButton : MonoBehaviour
{
    private Button _button;
    [SerializeField] private AudioClip buttonSound;
    private AudioSource _audioSource;
    private Image fade;
    private Coroutine _coroutine;

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
        _button = GetComponent<Button>();
        fade = GameObject.Find("FadeCanvas").GetComponentInChildren<Image>();
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
        _audioSource.PlayOneShot(buttonSound);
        yield return fade.DOFade(1.0f, 1.0f).WaitForCompletion();
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
