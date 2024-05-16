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

    [SerializeField] private Snake snake;
    

    private LevelGreed levelGreed;


    private void Awake()
    {
        instance = this;
        InitializeStatic();
    }
    private void Start() {
       // Debug.Log("GameHandler.Start");
        levelGreed = new LevelGreed(20, 20);
        snake.Setup(levelGreed);
        levelGreed.Setup(snake);

        CMDebug.ButtonUI(Vector2.zero, "Reload Scene", () =>
        {
            Loader.Load(Loader.Scene.SampleScene);
        });

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
}
