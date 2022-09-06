using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c4explosion : MonoBehaviour
{

    public float thrust = 20f;
    public GameObject grenade;
    Rigidbody rb_grenade;

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
            Destroy(rb_grenade.gameObject);
            yield return new WaitForFixedUpdate();

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // マウスの右クリックをしたとき
        {
             
        }
    }
}