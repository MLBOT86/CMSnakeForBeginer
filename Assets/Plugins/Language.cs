using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern string GetLang();



    public  string CurrentLanguage; //ru en
    [SerializeField] TextMeshProUGUI _languageText;



    public static Language Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
         ///  StartCoroutine(ShowCurrentLanguage());
        }
        else{
            Destroy(gameObject);
        }
    }
    private void Update()
    {
       

            CurrentLanguage = GetLang();
            _languageText.text = CurrentLanguage;
        
    }

    IEnumerator ShowCurrentLanguage()
    {

        CurrentLanguage = GetLang();
        _languageText.text = CurrentLanguage;

        yield return new WaitForSeconds(3f);
    }
}
