using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class c4explosion : MonoBehaviour
{

    public float thrust = 20f;
    public GameObject grenade;
    Rigidbody rb_grenade;
    [SerializeField] private float range;



    // Start is called before the first frame update
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
            rb_grenade.AddForce(Vector3.Lerp(transform.forward * 0.5f, -transform.up, 0.1f) * thrust, ForceMode.Impulse); // グレネードに力を一度加える
            Invoke("Explode", 0.01f);

            yield return new WaitForFixedUpdate();
            Destroy(rb_grenade.gameObject);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Explode()
    {
        // 爆発対象のチキンを取得
        var explodedChicken = GameObject.FindGameObjectsWithTag("Enemy")
        .Where(chicken => Vector3.Distance(chicken.transform.position, GameObject.FindGameObjectWithTag("c4").transform.position) <= range)
        .ToList();

        if (explodedChicken.Count == 0) return; // リストの要素が 0 の場合は何もしない


        foreach (var chicken in explodedChicken) // 配列に入れた一つひとつのオブジェクト
        {
            var rb = chicken.GetComponent<Rigidbody>();
            if (rb != null) // Rigidbodyがあれば、グレネードを中心とした爆発の力を加える
            {
                rb.AddExplosionForce(30f, GameObject.FindGameObjectWithTag("c4").transform.position, 15f, 5f, ForceMode.Impulse);

            }
        }

    }


}