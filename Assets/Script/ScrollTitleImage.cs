using UnityEngine;

public class ScrollTitleImage : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    private RectTransform _rectTransform;
    
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        _rectTransform.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        if (_rectTransform.localPosition.y >= 1250f)
        {
            var pos = _rectTransform.localPosition;
            _rectTransform.localPosition = new Vector3(pos.x, -2750f, pos.z);
        } 
    }
}
