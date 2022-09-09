using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Hiyokoboom : MonoBehaviour
{
    [SerializeField] private float desroytime;

    private PlayerExplosionPoint _playerExplosionPoint;
    public GameObject bigBombEffect;
    private GameObject SHIFT;
    private ScoreManager _scoreManager;
    private SameTimeExplosionCount _sameTimeExplosionCount;

    void Start()
    {
        _scoreManager = ScoreManager.Instance;
        _sameTimeExplosionCount = GameObject.Find("Canvas").GetComponentInChildren<SameTimeExplosionCount>();
        _playerExplosionPoint = GameObject.FindWithTag("Player").GetComponent<PlayerExplosionPoint>();
        SHIFT = GameObject.FindWithTag("SHIFT");
        SHIFT.SetActive(false);
    }
    
    void Update()
    {
        if (_playerExplosionPoint.ExplosionPoint >= PlayerExplosionPoint.MaxExplosionPoint)
        {
            SHIFT.SetActive(true);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerExplosionPoint.ResetExplosionPoint();
                Invoke("Boomhiyoko", 15);
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<HiyokoPatrol>().enabled = false;
            }
        }
    }

    void Boomhiyoko()
    {
        var explodedChicken = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        foreach (var chicken in explodedChicken)
        {
            var rb = chicken.GetComponent<Rigidbody>();
            if (rb != null)
            {
                GenerateEffect();
                rb.AddExplosionForce(30f, transform.position, 15f, 5f, ForceMode.Impulse);
                _sameTimeExplosionCount.Show(explodedChicken.Count); // 同時爆発数を表示
                _scoreManager.AddScore(explodedChicken.Count); // 点数を加える
                Destroy(chicken, desroytime);
                Destroy(this.gameObject);
            }
        }
    }
    
    void GenerateEffect()
    {
        GameObject effect = Instantiate(bigBombEffect);
        effect.transform.position = gameObject.transform.position;
    }
}

