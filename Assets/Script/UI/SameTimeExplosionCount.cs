using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SameTimeExplosionCount : MonoBehaviour
{
    [SerializeField] private List<Sprite> operatorSprites;
    [SerializeField] private Image operatorImage;
    [SerializeField] private Image hukidashi;
    [SerializeField] private Text hukidashiText;
    
    private Coroutine _coroutine;
    
    private void Start()
    {
        operatorImage.sprite = operatorSprites[0];
        hukidashi.gameObject.SetActive(false);
        hukidashiText.gameObject.SetActive(false);
    }

    public void Show(int count)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(ShowCoroutine(count));
    }

    private IEnumerator ShowCoroutine(int count)
    {
        hukidashiText.text = $"{count} 体、爆発！";
        operatorImage.sprite = operatorSprites[1];
        hukidashi.gameObject.SetActive(true);
        hukidashiText.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(1.5f);
        
        operatorImage.sprite = operatorSprites[0];
        hukidashi.gameObject.SetActive(false);
        hukidashiText.gameObject.SetActive(false);
    }
}
