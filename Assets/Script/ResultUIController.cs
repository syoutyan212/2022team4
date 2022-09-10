using System.Collections;
using DG.Tweening;
using naichilab;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIController : MonoBehaviour
{
    [SerializeField] private AudioClip chi;
    [SerializeField] private AudioClip doo;
    [SerializeField] private AudioClip piyopiyo;
    [SerializeField] private AudioClip bgm;
    
    [SerializeField] private Text resultText;
    [SerializeField] private Text explosionCountText;
    [SerializeField] private Text explosionSameCountText;
    [SerializeField] private Text scoreText;

    [SerializeField] private Button button;
    private Image fade;
    
    private IEnumerator Start()
    {
        var audio = GetComponent<AudioSource>();
        var model = GameObject.Find("ResultModel").GetComponent<ResultModel>();
        fade = GameObject.Find("FadeCanvas").GetComponentInChildren<Image>();
        
        fade.color = Color.black;
        fade.raycastTarget = true;
        yield return fade.DOFade(0.0f, 1.0f).WaitForCompletion();
        
        // リザルトタイトル出現
        audio.PlayOneShot(doo);
        yield return resultText.DOFade(1.0f, 0.1f).SetEase(Ease.InQuart).WaitForCompletion();
        yield return new WaitForSeconds(1.0f);
        // 総爆発数
        audio.PlayOneShot(chi);
        explosionCountText.text = $"爆発した数: {model.ExplosionCount}体";
        yield return explosionCountText.DOFade(1.0f, 0.1f).SetEase(Ease.InQuart).WaitForCompletion();
        yield return new WaitForSeconds(1.0f);
        
        // 最高同時爆発数
        audio.PlayOneShot(chi);
        explosionSameCountText.text = $"同時爆発数: {model.ExplosionSameCount}体";
        yield return explosionSameCountText.DOFade(1.0f, 0.1f).SetEase(Ease.InQuart).WaitForCompletion();
        yield return new WaitForSeconds(1.0f);
        
        // スコア
        audio.PlayOneShot(doo);
        scoreText.text = $"スコア: {model.Score}点";
        yield return scoreText.DOFade(1.0f, 0.1f).SetEase(Ease.InQuart).WaitForCompletion();
        yield return new WaitForSeconds(1.0f);
        
        RankingLoader.Instance.SendScoreAndShowRanking(100); // TODO 後で差し替え
        yield return new WaitForSeconds(1.0f);
        
        button.gameObject.SetActive(true);
        fade.raycastTarget = false;

        audio.clip = bgm;
        audio.loop = true;
        audio.Play();
        
        yield return new WaitForSeconds(0.5f);
        audio.PlayOneShot(piyopiyo);
        yield return new WaitForSeconds(1.0f);
        audio.PlayOneShot(piyopiyo);
        yield return new WaitForSeconds(1.0f);
        audio.PlayOneShot(piyopiyo);
    }
}
