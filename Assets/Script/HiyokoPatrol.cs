using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class HiyokoPatrol : MonoBehaviour
{
    public float speed;
    GameObject[] TargetPoints;
    GameObject marker0;
    GameObject marker1;
    GameObject marker2;
    GameObject marker3;
    private int target = 0;

    void Start()
    {
        marker0 = GameObject.Find("Marker0");
        marker1 = GameObject.Find("Marker1");
        marker2 = GameObject.Find("Marker2");
        marker3 = GameObject.Find("Marker3");
        TargetPoints = new GameObject[] { marker0, marker1, marker2, marker3 };
        
    }
    
    void Update()
    {
        if(Vector3.Distance(transform.position, TargetPoints[target % 4].transform.position)<= 0.05f)
        {
            target++;
            this.transform.LookAt(TargetPoints[target % 4].transform);
            
        }

        transform.position = Vector3.MoveTowards(transform.position, TargetPoints[target % 4].transform.position, speed * Time.deltaTime);
    }
}