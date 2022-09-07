using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float baitrange;
    [SerializeField] private float desroytime;

    public GameObject BombEffect;
    private ScoreManager _scoreManager;
    private SameTimeExplosionCount _sameTimeExplosionCount;
    private PlayerExplosionPoint _playerExplosionPoint;

    private void Start()
    {
        _scoreManager = ScoreManager.Instance;
        _sameTimeExplosionCount = GameObject.Find("Canvas").GetComponentInChildren<SameTimeExplosionCount>();
        _playerExplosionPoint = GameObject.FindWithTag("Player").GetComponent<PlayerExplosionPoint>();
        Invoke("Explode", 5);
        StartCoroutine(startbait());
    }

    IEnumerator startbait()
    {
        yield return new WaitForFixedUpdate();
        var explodedChicken = GameObject.FindGameObjectsWithTag("Enemy")
            .Where(chicken => Vector3.Distance(chicken.transform.position, transform.position) <= baitrange)
            .ToList();
        if (explodedChicken.Count == 0) yield break; // リストの要素が 0 の場合は何もしない

        _sameTimeExplosionCount.ShowText(explodedChicken.Count); // 同時爆発数を表示
        _scoreManager.AddScore(explodedChicken.Count); // 点数を加える

        foreach (var chicken in explodedChicken) // 配列に入れた一つひとつのオブジェクト
            chicken.GetComponent<Patrol>().Bait(gameObject);
    }

    private void Update()
    {

    }

    void Explode()
    {
        GenerateEffect();
        // 爆発対象のチキンを取得
        var explodedChicken = GameObject.FindGameObjectsWithTag("Enemy")
            .Where(chicken => Vector3.Distance(chicken.transform.position, transform.position) <= range)
            .ToList();

        if (explodedChicken.Count == 0)
        {
            Destroy(gameObject);
            return; // リストの要素が 0 の場合は何もしない
        }

        _sameTimeExplosionCount.ShowText(explodedChicken.Count); // 同時爆発数を表示
        // 同時爆発数分、爆発ポイントを加算
        if (_playerExplosionPoint.ExplosionPoint + explodedChicken.Count >= PlayerExplosionPoint.MaxExplosionPoint)
        {
            _playerExplosionPoint.ExplosionPoint = PlayerExplosionPoint.MaxExplosionPoint;
        }
        else
        {
            _playerExplosionPoint.ExplosionPoint += explodedChicken.Count;
        }

        _scoreManager.AddScore(explodedChicken.Count); // 点数を加える

        foreach (var chicken in explodedChicken) // 配列に入れた一つひとつのオブジェクト
        {
            var rb = chicken.GetComponent<Rigidbody>();
            if (rb != null) // Rigidbodyがあれば、グレネードを中心とした爆発の力を加える
            {
                rb.AddExplosionForce(30f, transform.position, 15f, 5f, ForceMode.Impulse);
                Destroy(chicken, desroytime);
                Destroy(gameObject);
            }
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        var playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.AddExplosionForce(30f, transform.position, 15f, 5f, ForceMode.Impulse);
        }
    }

    void GenerateEffect()
    {
        GameObject effect = Instantiate(BombEffect);
        effect.transform.position = gameObject.transform.position;
    }
}