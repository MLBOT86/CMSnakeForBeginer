using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWinodw : MonoBehaviour
{
    private Text scoreText;

    private void Awake()
    {
        scoreText = transform.Find("scoreText").GetComponent<Text>();
        int highscore= Score.GetHighScore();
        transform.Find("highscoreText").GetComponent<Text>().text="HIGHSCORE\n" + highscore.ToString();
    }
    private void Update()
    {
        scoreText.text = GameHandler.GetScore().ToString();
    }
}
