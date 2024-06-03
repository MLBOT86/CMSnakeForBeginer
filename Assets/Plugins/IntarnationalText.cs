using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntarnationalText : MonoBehaviour
{
    [SerializeField] string _en;
    [SerializeField] string _ru;


    private void Start()
    {


      //  StartCoroutine(TranslateCourutine());



    }
    IEnumerator TranslateCourutine()
    {


        if (Language.Instance.CurrentLanguage == "en")
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
        else if (Language.Instance.CurrentLanguage == "ru")
        {
            GetComponent<TextMeshProUGUI>().text += _ru;
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = _en;

        }


        yield return new WaitForSeconds(4f);
    }




}
