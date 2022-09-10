using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorRainbow : MonoBehaviour
{
    Image image;
    private bool keydown;

    void Start()
    {
        image = GetComponent<Image>();
    }

    private void OnDisable()
    {
        keydown = false;
    }

    void Update()
    {
        image.color = Color.HSVToRGB(Time.time % 1, 1, 1);

        if (Input.GetKeyDown(KeyCode.LeftShift) || keydown == true)
        {
            image.color = Color.gray;
            keydown = true;
        }
    }
}