using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public float Countdown = 90.0f;
    private Text timeText;
    private AudioSource _audioSource;
    AudioClip clip;
    private bool isFinish;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        clip = _audioSource.clip;
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(isFinish) return;
        
        if (GameManager.Instance.IsGaming)
        {
            Countdown -= Time.deltaTime;
            if (Countdown <= 0)
            {
                timeText.text = "TIME OUT";
                _audioSource.PlayOneShot(clip);
                GameManager.Instance.IsGaming = false;
                isFinish = true;
            }
            else
            {
                timeText.text = Countdown.ToString("f1") + "秒";
            }
        }
    }
}
