using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; set; }
    public int MaxSameExplosionCount { get; set; }
    public int ExplosionCount { get; set; }
    public static readonly int DEFAULT_SCORE = 10;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    // 爆発したオブジェクトの数に応じて追加されるスコアが変動する
    // (100 * 倒した数) * 倒した数
    public void AddScore(int explosionCount)
    {
        if (MaxSameExplosionCount < explosionCount)
        {
            MaxSameExplosionCount = explosionCount;
        }

        ExplosionCount += explosionCount;
        
        if (GameManager.Instance.IsGaming)
        {
            Score += DEFAULT_SCORE * explosionCount * explosionCount;
        }
    }
}
