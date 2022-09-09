using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class c4explosion : MonoBehaviour
{
    public float thrust = 20f;
    public GameObject grenade;
    public GameObject BombEffect;
    Rigidbody rb_grenade;
    [SerializeField] private float range;
    [SerializeField] private float desroytime;
    
    void Start()
    {
        rb_grenade = GetComponent<Rigidbody>();
        StartCoroutine(c4());
    }

    IEnumerator c4()
    {
        while (true)
            {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(1));
                rb_grenade = Instantiate(grenade, transform.position, transform.rotation).GetComponent<Rigidbody>();
                yield return new WaitForFixedUpdate();
                yield return new WaitUntil(() => Input.GetMouseButtonDown(1));
                rb_grenade.AddForce(Vector3.Lerp(transform.forward * 0.5f, -transform.up, 0.1f) * thrust, ForceMode.Impulse);
                Invoke("Explode", 0.01f);
                yield return new WaitForFixedUpdate();
                Destroy(rb_grenade.gameObject);
                
                yield return new WaitForSeconds(3.5f);
            }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        GenerateEffect();
        var explodedChicken = GameObject.FindGameObjectsWithTag("Enemy")
        .Where(chicken => Vector3.Distance(chicken.transform.position, GameObject.FindGameObjectWithTag("c4").transform.position) <= range)
        .ToList();
        
        var player = GameObject.FindGameObjectWithTag("Player");
        var playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.AddExplosionForce(30f, transform.position, 5f, 5f, ForceMode.Impulse);
        }

        if (explodedChicken.Count == 0) return; // ���X�g�̗v�f�� 0 �̏ꍇ�͉������Ȃ�
        foreach (var chicken in explodedChicken) // �z��ɓ��ꂽ��ЂƂ̃I�u�W�F�N�g
        {
            var rb = chicken.GetComponent<Rigidbody>();
            if (rb != null) // Rigidbody������΁A�O���l�[�h�𒆐S�Ƃ��������̗͂�������
            {
                rb.AddExplosionForce(30f, GameObject.FindGameObjectWithTag("c4").transform.position, 5f, 5f, ForceMode.Impulse);
                chicken.GetComponent<Patrol>().enabled = false;
                chicken.GetComponent<RandomMove>().enabled = false;
                chicken.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                chicken.GetComponent<ChickenExplodedState>().IsExploded = true;
                
                Destroy(chicken, desroytime);
            }
        }
        void GenerateEffect()
        {
            GameObject effect = Instantiate(BombEffect);
            effect.transform.position = gameObject.transform.position;
        }
    }
}