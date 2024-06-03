using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AdvManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();



    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {

          ShowAdv();
        }
    }


    private void GamePause()
    {
        //pause
        AudioListener.volume = 0.0f;
        Time.timeScale = 0.0f;
    }
    private void GameResume()
    {
        AudioListener.volume = 1.0f;
        Time.timeScale = 1.0f;
    }

}
