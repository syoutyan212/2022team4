using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private Text _text;
    
    private void Start()
    {
        _scoreManager = ScoreManager.Instance;
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.text = $"スコア: {_scoreManager.Score}";
    }
}
