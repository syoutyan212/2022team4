using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float countTime = 0;
    
    void Start()
    {

    }
    
    void Update()
    {
        countTime += Time.deltaTime;

        GetComponent<Text>().text = countTime.ToString("F2");
    }
}