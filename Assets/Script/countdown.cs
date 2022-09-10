using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public float Countdown = 90.0f;
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
        Countdown -= Time.deltaTime;
        timeText.text = Countdown.ToString("f1") + "秒";

        if (Countdown <= 0)
        {
            timeText.text = "TIME OUT";
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
