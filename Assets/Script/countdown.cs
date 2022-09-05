using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public float Countdown = 1.0f;
    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;
        timeText.text = Countdown.ToString("f1") + "•b";

        if (Countdown <= 0)
        {
            timeText.text = "I—¹";
        }
    }
}
