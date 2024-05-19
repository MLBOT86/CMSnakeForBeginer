using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuWindow : MonoBehaviour
{
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _howToPlayBtn;
    [SerializeField] private Button _leaderBordBTn;
    [SerializeField] private Button _howToPlayBack;
    [SerializeField] private Button _leaderBordBack;

    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _howToPlayWindow;
    [SerializeField] private GameObject _leaderBordWindow;


    private enum Sub
    {
        Main,
        HowToPlay,
        LeaderBord,
    }


    private void Start()
    {
        _playBtn?.onClick.AddListener(() => Loader.Load(Loader.Scene.SampleScene));
        _howToPlayBtn.onClick.AddListener(()=>ShowSub(Sub.HowToPlay));
        _leaderBordBTn.onClick.AddListener(() => ShowSub(Sub.LeaderBord));
        _howToPlayBack.onClick.AddListener(() => ShowSub(Sub.Main));
        _leaderBordBack.onClick.AddListener(() => ShowSub(Sub.Main));
    }

    private void ShowSub(Sub sub)
    {
        _mainMenu?.SetActive(false);
        _howToPlayWindow?.SetActive(false);
        _leaderBordWindow?.SetActive(false);

        switch(sub)
        {
            case Sub.Main:
                _mainMenu?.SetActive(true);
                break;
             case Sub.HowToPlay:
                _howToPlayWindow?.SetActive(true);
                break;
            case Sub.LeaderBord:
                _leaderBordWindow?.SetActive(true);
                break;



        }



    }
}
