using System;
using System.Collections;

using System.Runtime.InteropServices;
using TMPro;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{


    [DllImport("__Internal")]
    private static extern void RateGame();


    [DllImport("__Internal")]
    private static extern void GiveMePlayerData();

    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] RawImage _photo;


    public void HelloButton()
    {
        GiveMePlayerData();
    }


    public void SetName(string name)
    {
        _nameText.text = name;
    }

    public void SetPhoto(string url)
    {
        StartCoroutine(DownLoadImage( url));
    }

    IEnumerator DownLoadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        
            Debug.Log(request.error);
        
        else
        
            _photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        

    }

    public void RateGameBtn()
    {
        RateGame();
    }

}
