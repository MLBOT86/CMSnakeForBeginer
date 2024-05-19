using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{

    private static PauseWindow instance;
    [SerializeField] private Button _resume;
    [SerializeField] private Button _goToMainMenu;

    private void Awake()
    {
        instance = this;
        Hide();
    }
    private void Start()
    {

        _resume.onClick.AddListener(()=>GameHandler.ResumeGame());
        _goToMainMenu.onClick.AddListener(()=>Loader.Load(Loader.Scene.MainMenu));
    }

    private void Show()
    {
        gameObject.SetActive(true);

    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    public static void ShowStatic()
    {
        instance.Show();
    }

    public static void HideStatic()
    {
        instance.Hide();
    }
}
