using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float countdown = 90.0f;
    private Text timeText;
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        clip = gameObject.GetComponent<AudioSource>().clip;
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        timeText.text = countdown.ToString("f1") + "秒";

        if (countdown <= 0)
        {
            timeText.text = "TIME OUT";
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
