using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SameTimeExplosionCount : MonoBehaviour
{
    private Text _text;
    private Coroutine _coroutine;
    
    private void Start()
    {
        _text = GetComponent<Text>();
    }
    
    void Update()
    {
    }

    public void ShowText(int count)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(ShowTextCoroutine(count));
    }

    private IEnumerator ShowTextCoroutine(int count)
    {
        _text.text = $"同時爆発数: {count}";
        yield return new WaitForSeconds(1.5f);
        _text.text = "";
    }
}
