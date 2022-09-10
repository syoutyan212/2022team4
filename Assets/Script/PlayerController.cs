//PlayerController.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject Player;
    public GameObject Camera;
    public float speed;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    private float ii;
    // Use this for initialization

    public float stoptime = 90.0f;

    void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerTransform = transform.parent;
        CameraTransform = GetComponent<Transform>();

    }
	
    private void Update () {
        if (GameManager.Instance.IsGaming)
        {
            stoptime -= Time.deltaTime;

            if (stoptime > 0)
            {
                var X_Rotation = Input.GetAxis("Mouse X");
                var Y_Rotation = Input.GetAxis("Mouse Y");
                PlayerTransform.transform.Rotate(0, X_Rotation, 0);
        
                ii = Camera.transform.localEulerAngles.x;
                if (ii > 314 && ii < 360 || ii > 0 && 79 > ii)
                {
                    CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
                    float kk = Y_Rotation;
                }
                else
                {
           
                    if (ii > 300)
                    {
 
                        if (Input.GetAxis("Mouse Y") < 0)
                        {
 
                            CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
 
                        }
                    }
                    else
                    {
                        if (Input.GetAxis("Mouse Y") > 0)
                        {
 
                            CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
 
                        }
 
                    }
                }
                
                float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
                Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
                Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

                if (Input.GetKey(KeyCode.W))
                {
                    PlayerTransform.transform.position += dir1 * speed * Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.A))
                {
                    PlayerTransform.transform.position += dir2 * speed * Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    PlayerTransform.transform.position += -dir2 * speed * Time.deltaTime;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    PlayerTransform.transform.position += -dir1 * speed * Time.deltaTime;
                }
            }

            if (stoptime <= 0)
            {
                Time.timeScale = 0;
                PlayerTransform.transform.Rotate(0, 0, 0);
                CameraTransform.transform.Rotate(0, 0, 0);

            }
        }
    }
}