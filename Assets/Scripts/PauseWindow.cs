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
        if (instance == null)
        { // Ёкземпл€р менеджера был найден
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (instance == this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }
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
