using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Hiyokoboom : MonoBehaviour
{
    [SerializeField] private float desroytime;
    [SerializeField] private GameObject SHIFT;
    
    private PlayerExplosionPoint _playerExplosionPoint;
    public GameObject bigBombEffect;
    
    void Start()
    {
        SHIFT.SetActive(false);
        _playerExplosionPoint = GameObject.FindWithTag("Player").GetComponent<PlayerExplosionPoint>();
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

