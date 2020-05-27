using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Controller : MonoBehaviour
{
    public Enter_Again level_Completion;
    private TextMeshProUGUI scoreText;
    private int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        
    }
    private void Start()
    {
        RefreshUI();
    }

    private void Update()
    {
        if(score == 40)
        {
          gameObject.SetActive(false);
          Level_Manager.Instance.MarkCurrentLevelCompleted();
          level_Completion.PlayerDied();
        }
    }

    public void Increase_Score (int increment)
    {
        score += increment;
        RefreshUI();
    }
    void RefreshUI()
    {
        scoreText.text = "Score:" + score;
    }
}
