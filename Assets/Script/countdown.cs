using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float countdown = 180.0f;
    private Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        timeText.text = countdown.ToString("f1") + "秒";

        if (countdown <= 0)
        {
            timeText.text = "時間になりました！";
        }
    }
}
