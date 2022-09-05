using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump2dan : MonoBehaviour
{
    int jumpCount = 0;
    public Rigidbody rb;

    void Update()
    {
        if (jumpCount < 1 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(0f,500f,0f);
            jumpCount++;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }
    }
}