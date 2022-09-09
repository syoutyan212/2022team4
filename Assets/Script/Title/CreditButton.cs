using UnityEngine;
using UnityEngine.UI;

public class CreditButton : MonoBehaviour
{
    private Button _button;
    private TitleAudio _titleAudio;
    private Coroutine _coroutine;
    [SerializeField] private GameObject credit;

    private void Start()
    {
        _button = GetComponent<Button>();
        _titleAudio = GameObject.Find("Audio").GetComponent<TitleAudio>();
    }

    public void OnClick()
    {
        _titleAudio.ShotButtonSound();
        credit.gameObject.SetActive(true);
    }
}
