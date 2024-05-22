/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    private static GameHandler instance;


    private static int score;
    private const string HIGH_SCORE = "highscore";

    [SerializeField] private Snake snake;
    

    private LevelGreed levelGreed;


    private void Awake()
    {
        instance = this;
        InitializeStatic();
        Time.timeScale = 1f;
        PlayerPrefs.SetInt(HIGH_SCORE, 666);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt(HIGH_SCORE));
    }
    private void Start() {
       // Debug.Log("GameHandler.Start");
        levelGreed = new LevelGreed(20, 20);
        snake.Setup(levelGreed);
        levelGreed.Setup(snake);

       

        //int number = 0;

       // FunctionPeriodic.Create(() =>
       // {
           // CMDebug.TextPopupMouse("Ding!" + number);
          //  number++;
      //  },.3f);


       // GameObject snakeHeadGameObject = new GameObject();
       // SpriteRenderer snakeSpriteRenderer = snakeHeadGameObject.AddComponent<SpriteRenderer>();
       // snakeSpriteRenderer.sprite = GameAssets.i.snakeHeadSprite;
    }


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsGamePaused())
            {
                GameHandler.ResumeGame();
            }
            else
            {
                GameHandler.PauseGame();
            }
            
        }
    }
    private static void InitializeStatic()
    {
        score = 0;
    }
    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 100;
    }
    public static void SnakeDied() {
        GameOverWindow.ShowStatic();
    }

    public static void ResumeGame() { 

        PauseWindow.HideStatic();
        Time.timeScale = 1f;

    }

    public static void PauseGame() {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }

    public static bool IsGamePaused() {
    return Time.timeScale == 0f;
    }
}
