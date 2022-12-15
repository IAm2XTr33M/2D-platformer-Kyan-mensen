using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public float TotalTime;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeText;

    private void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        TotalTime += Time.deltaTime;
        TimeText.text = "Time: " + TotalTime.ToString();
    }

    public void AddScore()
    {
        Score++;
        ScoreText.text = "Score: " + Score.ToString();
    }

}
