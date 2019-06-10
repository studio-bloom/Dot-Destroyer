using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreDisplay : MonoBehaviour
{
    [SerializeField] Text scoreTextOnLose;
    [SerializeField] Text highScoreTextOnLose;
    int score;

    void Start()
    {
        score = FindObjectOfType<GameSessionManager>().score;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        scoreTextOnLose.text = "Your score is " + score.ToString()+ " !";
        highScoreTextOnLose.text = "Your highscore is " + PlayerPrefs.GetInt("HighScore", 0).ToString() + " !";
        FindObjectOfType<MoneyManager>().AddMoney(score);
    }
}
