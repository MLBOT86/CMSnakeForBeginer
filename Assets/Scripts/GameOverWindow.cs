using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameOverWindow : MonoBehaviour
{
    private static GameOverWindow instance;
    [SerializeField] private GameObject _newHighscoreText;
    [SerializeField] private Text _scorText;
    [SerializeField] private Text _highscoreText;
    private void Awake()
    {
        instance = this;
        transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Loader.Load(Loader.Scene.SampleScene);
          
        };
        Hide();
    }
    private void Show(bool isNewHighscore)
    {
        gameObject.SetActive(true);
        
        //transform.Find("newHighscoreText").gameObject.SetActive(isNewHighscore);
       // transform.Find("scoreText").GetComponent<Text>().text =Score.GetScore().ToString();
       // transform.Find("highscoreText").GetComponent<Text>().text="HIGHSCORE"+ Score.GetHighScore().ToString();

        _newHighscoreText.SetActive(isNewHighscore);
        _scorText.text = Score.GetScore().ToString();
        _highscoreText.text ="HIGHSCORE" + Score.GetHighScore().ToString();
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    public static void ShowStatic(bool isNewHighscore)
    {
        instance.Show(isNewHighscore);
    }
}
