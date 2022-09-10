using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dansuuhyoji : MonoBehaviour
{
    private Text dansuuText;
    private ThrowGrenadeScript grenadescript;
    private float grenadelimit;
    

    // Start is called before the first frame update
    void Start()
    {
        dansuuText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("Hand");
        grenadescript = obj.GetComponent<ThrowGrenadeScript>();
        grenadelimit = grenadescript.shotlimit;
        dansuuText.text = "écÇËíeêîÅF" + grenadelimit.ToString();
    }
}
