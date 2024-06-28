using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForSDK());
    }

    IEnumerator waitForSDK()
    {

       
        yield return new WaitForSeconds(3f);
        Loader.Load(Loader.Scene.MainMenu);
    }
}
