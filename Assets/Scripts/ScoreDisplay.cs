using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;
    
    private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
        ScoreManager.Instance.OnAddScore += UpdateScore;
        UpdateScore();
    }

    private void UpdateScore()
    {
        ScoreText.text = "Score " + ScoreManager.Instance.Score;
    }
}
