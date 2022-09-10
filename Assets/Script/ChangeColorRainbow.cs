using UnityEngine;
using UnityEngine.UI;

public class ChangeColorRainbow : MonoBehaviour
{
    Image image;
    private bool keydown;

    void Start()
    {
        image = GetComponent<Image>();
        keydown = false;
    }

    void Update()
    {
        image.color = Color.HSVToRGB(Time.time % 1, 1, 1);

        if (Input.GetKeyDown(KeyCode.LeftShift) || keydown == true)
        {
            keydown = true;
            image.color = Color.gray;
        }
    }
}