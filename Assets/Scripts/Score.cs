using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public  static class Score {

    public static event Action OnHightscoreChanged;

    private static int score;
   public static void InitializeStatic()
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
    public static int GetHighScore()
    {
      // PlayerPrefs.SetInt("highscore", 100);
        //PlayerPrefs.Save();
        return PlayerPrefs.GetInt("highscore", 0);
    }


    public static bool TrySetNewHighscore()
    {
        return TrySetNewHighscore(score);
    }
        public static bool TrySetNewHighscore(int score) {

        int highscore = GetHighScore();
        if (score > highscore)
        {
           // Debug.Log("sore>highscore");
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            OnHightscoreChanged?.Invoke();
            return true;
        }
        else
        {
            return false;
        }
        
            
        
    }
}
    

