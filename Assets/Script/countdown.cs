using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
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
                if (isFinish) return; 
                timeText.text = "TIME OUT";
                _audioSource.PlayOneShot(clip);
                GameManager.Instance.IsGaming = false;
                isFinish = true;
                StartCoroutine(OnFinishGame());
            }
            else
            {
                timeText.text = Countdown.ToString("f1") + "秒";
            }
        }
    }

    private IEnumerator OnFinishGame()
    {
        var fade = GameObject.Find("FadeCanvas").GetComponentInChildren<Image>();
        fade.raycastTarget = true;
        yield return new WaitForSeconds(3.0f);
        yield return fade.DOFade(1.0f, 1.0f).WaitForCompletion();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Result");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var model = GameObject.Find("ResultModel").GetComponent<ResultModel>();
        model.Score = ScoreManager.Instance.Score;
        model.ExplosionCount = ScoreManager.Instance.ExplosionCount;
        model.ExplosionSameCount = ScoreManager.Instance.MaxSameExplosionCount;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
