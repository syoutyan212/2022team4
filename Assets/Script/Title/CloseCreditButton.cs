using UnityEngine;
using UnityEngine.UI;

public class CloseCreditButton : MonoBehaviour
{
    private Button _button;
    private TitleAudio _titleAudio;
    private Coroutine _coroutine;

    private void Start()
    {
        _button = GetComponent<Button>();
        _titleAudio = GameObject.Find("Audio").GetComponent<TitleAudio>();
    }

    public void OnClick()
    {
        _titleAudio.ShotButtonSound();
        transform.parent.gameObject.SetActive(false);
    }
}
