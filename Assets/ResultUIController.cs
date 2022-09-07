using System.Collections;
using DG.Tweening;
using naichilab;
using UnityEngine;
using UnityEngine.UI;

public class ResultUIController : MonoBehaviour
{
    [SerializeField] private Text resultText;
    
    private IEnumerator Start()
    {
        // リザルトタイトル出現
        yield return resultText.DOFade(1.0f, 1.0f).SetEase(Ease.InQuart).WaitForCompletion();
        RankingLoader.Instance.SendScoreAndShowRanking(100); // TODO 後で差し替え
    }
}
