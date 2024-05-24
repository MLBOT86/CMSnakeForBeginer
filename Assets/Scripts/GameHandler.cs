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


   
   // private const string HIGH_SCORE = "highscore";

    [SerializeField] private Snake snake;
    

    private LevelGreed levelGreed;


    private void Awake()
    {
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance == this)
        { // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }
        Score.InitializeStatic();
        Time.timeScale = 1f;
      // Score.TrySetNewHighscore(100);
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
    
    public static void SnakeDied() {

        bool isNewHighscore =  Score.TrySetNewHighscore();
        Debug.Log( "bool" +isNewHighscore);
        GameOverWindow.ShowStatic(isNewHighscore);
        ScoreWinodw.HideStatic();
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
