using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ThrowGrenadeScript : MonoBehaviour
{
    public float thrust = 20f;
    public GameObject grenade;
    Rigidbody rb_grenade;
 
    // Start is called before the first frame update
    void Start()
    {
        rb_grenade = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウスの左クリックをしたとき
        {
            rb_grenade = Instantiate(grenade, transform.position, transform.rotation).GetComponent<Rigidbody>(); // グレネードを生成
            rb_grenade.AddForce(Vector3.Lerp(transform.forward * 1.5f,transform.up, 0.5f) * thrust, ForceMode.Impulse); // グレネードに力を一度加える
        }
    }
}