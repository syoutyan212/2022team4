using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaveGranade : MonoBehaviour
{
    [SerializeField] private List<Image> granades;
    private ThrowGrenadeScript _throwGrenadeScript;
    private Color defaultColor;
    private int prevCount;
    
    private void Start()
    {
        _throwGrenadeScript = GameObject.FindWithTag("Player").GetComponentInChildren<ThrowGrenadeScript>();
        prevCount = ThrowGrenadeScript.MaxGranadeCount;
        defaultColor = granades[0].color;
    }

    private void Update()
    {
        if(_throwGrenadeScript.granadeCount == prevCount) return;
        var count = _throwGrenadeScript.granadeCount;
        if (0 <= count && count <= 5)
        {
            UpdateGranadesUI(_throwGrenadeScript.granadeCount);
            prevCount = count;
        }
    }

    private void UpdateGranadesUI(int count)
    {
        for (var i = 0; i < ThrowGrenadeScript.MaxGranadeCount; i++)
        {
            if (i < count)
            {
                granades[i].color = defaultColor;
            }
            else
            {
                granades[i].color = Color.clear;
            }
        }
    }
}
