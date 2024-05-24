using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWinodw : MonoBehaviour
{
    private static ScoreWinodw instance;
    private Text scoreText;

    private void Awake()
    {
        instance = this;
        scoreText = transform.Find("scoreText").GetComponent<Text>();

        Score.OnHightscoreChanged += Score_OnHighscoreCHanged;
        UpdateHighscore();
       
    }
    private void Score_OnHighscoreCHanged()
    {
        //Debug.Log("swapScore");
        UpdateHighscore();
    }

   
    private void Update()
    {
        scoreText.text = Score.GetScore().ToString();
    }

    private void UpdateHighscore()
    {
        int highscore = Score.GetHighScore();
        transform.Find("highscoreText").GetComponent<Text>().text = "HIGHSCORE\n" + highscore.ToString();
    }
    public static void HideStatic()
    {
        instance.gameObject.SetActive(false);
    }
}
