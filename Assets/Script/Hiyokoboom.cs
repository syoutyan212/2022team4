using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hiyokoboom : MonoBehaviour
{
    [SerializeField] private float desroytime;
    
    private ScoreManager _scoreManager;
    public GameObject bigBombEffect;
    
    void Start()
    {
        _scoreManager = ScoreManager.Instance;
    }
    
    void Update()
    {
        if (_scoreManager.Score >= 1000)
        {
            Debug.Log("たまったよ");
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Invoke("Boomhiyoko", 15);
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<HiyokoPatrol>().enabled = false;
            }
        }
    }

    void Boomhiyoko()
    {
        var explodedChicken = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var chicken in explodedChicken)
        {
            var rb = chicken.GetComponent<Rigidbody>();
            if (rb != null)
            {
                GenerateEffect();
                rb.AddExplosionForce(30f, transform.position, 15f, 5f, ForceMode.Impulse);
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

